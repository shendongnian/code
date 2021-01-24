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
        //finally will always run, no matter the outcome, it will ALWAYS run;
        if (response != null)
        {
            DoSomething();
        }
    }
