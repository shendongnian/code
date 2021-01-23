    static void Main(string[] args)
    {
        // Test with a non-empty list of integers.
        GenericList<int> gll = new GenericList<int>();
        gll.AddNode(5);
        gll.AddNode(4);
        gll.AddNode(3);
        int intVal = gll.GetFirstAdded();
        // The following line displays 5.
        System.Console.WriteLine(intVal);
    }
