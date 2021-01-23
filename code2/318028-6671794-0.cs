    string ParseCounters()
    {
        string counterm = "";
        
        ...
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            ...
            counterm = line + "_2"
        }
        ...
        return counterm;
    }
    public static void test()
    {
        Console.WriteLine(ParseCounter());
        Console.ReadLine();
    }
