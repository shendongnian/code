    {
    	rdOnAllDone(rdOnAllDoneCallback);
    }
    
    private static void rdOnAllDoneCallback(int parameter)
    {
        Console.WriteLine("rdOnAllDoneCallback invoked, parameter={0}", parameter);
    }
