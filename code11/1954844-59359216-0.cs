    List<int> lista = new List<int>() { 3, 4, 9, 8, 5, 6, 0, 3, 8, 3 };
    // int number = lista.Count(n => n <= 5);
    List<int> listb = new List<int>();
    foreach(int n in lista)
    {
        if (n <= 5)
            listb.Add(n);
    }
    int number = listb.Count();
