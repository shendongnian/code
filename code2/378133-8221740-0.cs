    void FirstMethod()
    {
        var myQuery = from XType x in y select x.Stuff;
        SecondMethod(myQuery);
    }
    
    void SecondMethod(IEnumerable<XType> yourVariable)
    {
        // Will run the query on the next line.
        foreach(XType x in yourVariable)
        {
            Console.WriteLine(x.ToString());
        }
    }
