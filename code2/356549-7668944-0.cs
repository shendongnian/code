    class SomeClass 
    {
       public void ProductionOperation()
       {
          //Doin' production stuff
           Log(someProductionVariable);
       }
       [Conditional("DEBUG")]
       public static void Log(string message) 
       {
           //Write to a file
       }
    }
