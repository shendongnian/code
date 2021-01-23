    var userName = "bob";
    try 
    {      
       client.MyWebService(userName);
    }
    catch(Exception ex)
    {
       //Maybe we know WellKnownExceptions and can provide Foo advice:
       if (ex is WellKnownException)
       {
           Console.WriteLine("WellKnownException encountered, do Foo to fix Bar.");
       }
       //otherwise, this is the best you can do:
       Console.WriteLine(string.Format(
             "MyWebService call failed for {0}. Details: {1}", userName, ex));
    }
