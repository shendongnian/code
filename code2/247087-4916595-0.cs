    public void InstallUserCommands(IWindsorContainer container)
    {
                    
      var commandToClassMappings = new Dictionary<string, string>
                                {
                                  {"move", "MoveCommand"},
                                  {"locate","LocateSelfCommand"},
                                  {"lookaround","LookAroundCommand"},
                                  {"bag","LookInBagCommand"}
                                };
    
      foreach (var command in commandToClassMappings)
      {
         var commandType = Type.GetType("TheGrid.Commands.UserInputCommands." + command.Value);
         container.Register(Component.For(commandType).Named(command.Key));
    
      }
    }
