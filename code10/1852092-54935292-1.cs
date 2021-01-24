    Random rand = new Random();
    int[] a = { rand.Next(100,999), rand.Next(100, 999), rand.Next(100, 999), rand.Next(100, 999) };    // random numbers
    string[] inty = { "k", "l", "m", "n" };    
    var variables = new Dictionary<string, int>();
    for (int i = 0; i<a.Length; i++)
    {
        variables.Add(inty[i], a[i]);
        Console.WriteLine(variables[inty[i]]);
    }
    //example using a variable
    Console.WriteLine($"k: {variables["k"]}");
    Console.ReadKey();
