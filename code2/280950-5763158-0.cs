    using System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions
    
    [HandleProcessCorruptedStateExceptions]
    public static int Main()
    {
        try
        {
            // Catch any exceptions leaking out of the program
            CallMainProgramLoop();
        }
        catch (Exception e) // We could be catching anything here
        {
            System.Console.WriteLine(e.Message);
            return 1;
        }
        return 0;
      } 
