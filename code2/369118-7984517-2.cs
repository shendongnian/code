    string message;
    List<Balance> result;
    if (!TryGetBalanceFinale(periode, out result, out message))
    {
        // examine the msg one way or another
        Console.WriteLine(message); 
    }
    else
    {
        // you know the method succeeded, so use result
        Console.WriteLine("The result is: " + result.ToString()); 
    }
