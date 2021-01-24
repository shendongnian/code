    static void Main(string[] args)
    {
        List<int> array = new List<int>();
        StreamReader SR = new StreamReader("Data.Txt");
        
        while (!SR.EndOfStream)
        {
            array.Add(int.Parse(SR.ReadLine()));
        }
        Console.WriteLine("ARRAY BEFORE SORTING" );
        for (int x = 0; x < array.Count; x++)
        {
            Console.WriteLine(array[x]);
        }
        Console.ReadLine();
    }
