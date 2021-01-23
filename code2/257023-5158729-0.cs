    var results = listTwo.Intersect(listOne).Concat(listOne.Except(listTwo));
    foreach (string r in results)
    {
        Console.WriteLine(r);
    }
