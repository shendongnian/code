    public class MyWarningException : Exception() {}
    
    ...
    
    try
    { 
         obj.DoSomething(id,input);
    }
    catch (MyWarningException ex)
    {
         // do stuff
    }
