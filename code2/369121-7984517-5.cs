    string message;
    List<Balance> result;
    if (!TryGetBalanceFinale(periode, out result, out message))
    {
        // examine the msg because you know the method failed
        Console.WriteLine(message); 
    }
    else
    {
        // you know the method succeeded, so use the result
        Console.WriteLine("The result is: " + result.ToString()); 
    }
