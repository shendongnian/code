    public void Linq50()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };
     
        var commonNumbers = numbersA.Intersect(numbersB);
     
        Console.WriteLine("Common numbers shared by both arrays:");
        foreach (var n in commonNumbers)
        {
            Console.WriteLine(n);
        }
    }
