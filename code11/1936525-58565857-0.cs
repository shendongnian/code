    public static void Main() 
    {
        var map = new Dictionary<(int, int), int>();
        map.Add((1, 2), 3);
        map.Add((1, 2), 4); // Throw an exception
    }
