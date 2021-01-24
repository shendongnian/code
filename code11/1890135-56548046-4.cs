    try
    {
        DoTheUsual();
    }
    catch(WebException webEx)
    {
        //we won't need an if condition in here because we have the exception
        DoSomething();
    }
