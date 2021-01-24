    int[] Counters = {1, 2, 3, 4, 5};
    foreach (int counter in Counters)
    {
        if (counter == 3) Console.WriteLine("3 OAK A pays" + PayCombos[2]);
        else if (counter == 4) Console.WriteLine("4 OAK A pays" + PayCombos[1]);
        else if (counter == 5) Console.WriteLine("5 OAK A pays" + PayCombos[0]);
    }
