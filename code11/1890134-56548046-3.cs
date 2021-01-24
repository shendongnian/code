    WebException response = new WebException();
    try
    {
        DoTheUsual();
    }
    catch(WebException webEx)
    {
        response = webEx;
    }
    finally
    {
        //finally will ALWAYS run, no matter the outcome
        if (response != null)
            DoSomething();
    }
