    class Program
    {
      public static void Main()
      {
        // ... load Instrument.dll into assembly object ...
        // ... load the type from the assembly ...
        IInstrument instrument_ = (IInstrument)Activator.CreateInstance(classType);
        instrument_.instrumentCommand(cmd.getCommandName()); 
      }
    }
