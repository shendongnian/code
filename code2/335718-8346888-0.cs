    Log.WriteLine(Environment.StackTrace)
    try
    {
        SomethingThatThrowsAnException();
    }
    catch (Exception e)
    {
        Log.WriteLine(e.StackTrace); // better to do Log.WriteLine(e) to get the message
    }
