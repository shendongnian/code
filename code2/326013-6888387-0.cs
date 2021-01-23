    class CommandData
    {
      public string StringData {get; set;}
    }
    
    class ExtendedCommandData : CommandData
    {
      public int I {get;set;}
    }
    
    interface IMyInterface
    {
      public void Execute(CommandData commandData);
    }
    
    class MyClass1 : IMyInterface
    {
      pubic void Execute(CommandData commandData);
    }
    class MyClass2 : IMyInterface
    {
      // Lets impelment this interface explicitely
      void IMyInterface.Execute(CommandData commandData)
      {
      }
      
      void Execute(ExtendedCommandData extendedData)
      {
        // now we can access to string and int parameter
      }
    }
