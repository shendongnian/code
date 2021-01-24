    public Tuple<int, int> ViaClassicTuple()
    {
       return new Tuple<int, int>(1,2);
    }
    
    ...
    var tuple = ViaClassicTuple();
    Console.WriteLine($"{tuple.Item1}, {tuple.Item2}");
