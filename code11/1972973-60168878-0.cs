    int idade2 = Convert.ToInt32(Console.ReadLine());
    if (int.TryParse(Console.ReadLine(), out int idade2)
    {
        pessoa.idade = idade2;
    }
    else
    {
        Console.WriteLine("Insira um número não uma string:");
    }
