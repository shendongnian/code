    private static void FireTheGun(int bulletsCount)
    {
        var ratata = Enumerable.Repeat("Ta", bulletsCount).Prepend("Ra");
        Console.WriteLine(String.Join("-", ratata));
    }
