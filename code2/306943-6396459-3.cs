    string[] sizes = new string[] { "105", "101", "102", "103", "90" };
    foreach (var size in sizes.OrderBy(x => {
        double sum = 0;
        int position = 0;
        foreach (char c in x.ToCharArray().Reverse()) {
            sum += (c - 48) * (int)(Math.Pow(10,position));
            position++;
        }
        return sum;
    }))
    
    {
        Console.WriteLine(size);
    }
