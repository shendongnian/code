    int min = tablica[0];
    for (int i = 0; i < tablica.Length; i++)
    {
        Console.WriteLine("Podaj wartosc {0} elementu.", i + 1);
        tablica[i] = Convert.ToInt32(Console.ReadLine());
    }
