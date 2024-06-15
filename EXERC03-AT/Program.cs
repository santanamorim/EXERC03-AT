using System;
using System.Collections.Generic;

public abstract class ItemBiblioteca
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }

    public ItemBiblioteca(string titulo, string autor, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
    }

    public abstract void Emprestar();
    public abstract void Devolver();
    public abstract void ExibirInformacoes();
}

public interface IEmprestavel
{
    bool VerificarDisponibilidade();
    DateTime ObterPrazoDeDevolucao();
}

public class Livro : ItemBiblioteca, IEmprestavel
{
    public string ISBN { get; set; }
    private bool emprestado;

    public Livro(string titulo, string autor, int anoPublicacao, string isbn)
        : base(titulo, autor, anoPublicacao)
    {
        ISBN = isbn;
        emprestado = false;
    }

    public override void Emprestar()
    {
        if (!emprestado)
        {
            emprestado = true;
            Console.WriteLine($"O livro \"{Titulo}\" foi emprestado.");
        }
        else
        {
            Console.WriteLine($"O livro \"{Titulo}\" já está emprestado.");
        }
    }

    public override void Devolver()
    {
        if (emprestado)
        {
            emprestado = false;
            Console.WriteLine($"O livro \"{Titulo}\" foi devolvido.");
        }
        else
        {
            Console.WriteLine($"O livro \"{Titulo}\" já está na biblioteca.");
        }
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"Livro: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Ano de Publicação: {AnoPublicacao}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Status: {(emprestado ? "Emprestado" : "Disponível")}");
        Console.WriteLine();
    }

    public bool VerificarDisponibilidade()
    {
        return !emprestado;
    }

    public DateTime ObterPrazoDeDevolucao()
    {
        return DateTime.Now.AddDays(14); // Exemplo: 14 dias de prazo
    }
}

public class Revista : ItemBiblioteca, IEmprestavel
{
    public string Edicao { get; set; }
    private bool emprestado;

    public Revista(string titulo, string autor, int anoPublicacao, string edicao)
        : base(titulo, autor, anoPublicacao)
    {
        Edicao = edicao;
        emprestado = false;
    }

    public override void Emprestar()
    {
        if (!emprestado)
        {
            emprestado = true;
            Console.WriteLine($"A revista \"{Titulo}\" foi emprestada.");
        }
        else
        {
            Console.WriteLine($"A revista \"{Titulo}\" já está emprestada.");
        }
    }

    public override void Devolver()
    {
        if (emprestado)
        {
            emprestado = false;
            Console.WriteLine($"A revista \"{Titulo}\" foi devolvida.");
        }
        else
        {
            Console.WriteLine($"A revista \"{Titulo}\" já está na biblioteca.");
        }
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"Revista: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Ano de Publicação: {AnoPublicacao}");
        Console.WriteLine($"Edição: {Edicao}");
        Console.WriteLine($"Status: {(emprestado ? "Emprestada" : "Disponível")}");
        Console.WriteLine();
    }

    public bool VerificarDisponibilidade()
    {
        return !emprestado;
    }

    public DateTime ObterPrazoDeDevolucao()
    {
        return DateTime.Now.AddDays(7); // Exemplo: 7 dias de prazo
    }
}

public class Biblioteca
{
    private List<ItemBiblioteca> itens;

    public Biblioteca()
    {
        itens = new List<ItemBiblioteca>();
    }

    public void AdicionarItem(ItemBiblioteca item)
    {
        itens.Add(item);
    }

    public void RemoverItem(ItemBiblioteca item)
    {
        itens.Remove(item);
    }

    public void ExibirItens()
    {
        foreach (var item in itens)
        {
            item.ExibirInformacoes();
        }
    }

    public void RealizarEmprestimo(ItemBiblioteca item)
    {
        item.Emprestar();
    }

    public void RealizarDevolucao(ItemBiblioteca item)
    {
        item.Devolver();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        Livro livro1 = new Livro("Aprendendo C#", "José da Silva", 2020, "1234567890");
        Livro livro2 = new Livro("Design Patterns", "João Pereira", 2015, "0987654321");
        Revista revista1 = new Revista("Scientific American", "Editora XYZ", 2023, "Vol. 100, No. 2");

        biblioteca.AdicionarItem(livro1);
        biblioteca.AdicionarItem(livro2);
        biblioteca.AdicionarItem(revista1);

        Console.WriteLine("Lista de itens na biblioteca:");
        biblioteca.ExibirItens();

        Console.WriteLine("Realizando empréstimo do livro \"Aprendendo C#\":");
        biblioteca.RealizarEmprestimo(livro1);

        Console.WriteLine("Lista de itens na biblioteca após empréstimo:");
        biblioteca.ExibirItens();

        Console.WriteLine("Devolvendo o livro \"Aprendendo C#\":");
        biblioteca.RealizarDevolucao(livro1);

        Console.WriteLine("Lista de itens na biblioteca após devolução:");
        biblioteca.ExibirItens();
    }
}