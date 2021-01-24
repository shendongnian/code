    int max = Int.MinValue;
    int min = Int.MaxValue;
    int maxindex = -1;
    int minindex = -1;
    for (int i = 0; i < tablica.Length; i++)
    {
       if (tablica[i] > max) { max = tablica[i]; maxindex = i; }
       if (tablica[i] < min) { min = tablica[i]; minindex = i; }
    }
