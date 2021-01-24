    Random rand = new Random();
    int[] a = { rand.Next(100,999), rand.Next(100, 999), rand.Next(100, 999), rand.Next(100, 999) };    // random numbers
    string[] inty = { "k", "l", "m", "n" };   
    var variables = new Dictionary<string, int>(); 
    foreach (var item in a.Zip(inty, (i, n) => (i, n)))
    {
        variables.Add(item.i, item.n);
    }
    //example using a variable
    Console.WriteLine($"k: {variables["k"]}");
    Console.ReadKey();
