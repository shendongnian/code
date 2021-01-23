    try
    {
        ...
        double result = client.Add(value1, value2);
        ...
        client.Close();
    }
    catch (TimeoutException exception)
    {
        Console.WriteLine("Got {0}", exception.GetType());
        client.Abort();
    }
    catch (CommunicationException exception)
    {
        Console.WriteLine("Got {0}", exception.GetType());
        client.Abort();
    }
