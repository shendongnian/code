    void Undo()
    {
        if (result.Count==0)
        {
            Console.WriteLine("UNDO IS NOT AVAILABLE");
        }
        result.Pop(); //Remove current total from last expression
        total = result.Peek(); //Take previous total
        Console.WriteLine("Running total:{0}", total);
    }  
