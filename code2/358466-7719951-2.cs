    public void KeyCommandFactory{
       public static GetKeyCommand(IKeyCommandInfo info){
          Type type = Type.GetType("Namespace.To." + info.CommandName + "Command");
          return (IKeyCommandInfo)Activator.CreateInstance(type, info); // Add this property
       }
    }
