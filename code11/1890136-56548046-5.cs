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
        //If an exception occured, DoSomething() will execute, 
        //else your code will move on
        if (response != null) DoSomething();
    }
