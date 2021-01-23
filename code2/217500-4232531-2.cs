    internal void Configure(ButtonEventArgs args, IBroker broker, FunctionEntry entry)  
    {
          int phase = broker.TradingPhase;
          foreach(var action in MyActions[phase])
          {
               action(args, entry);
          }  
     }
    internal void PopulateMyActions()
    {
          // Hopefully I have not made a syntax error in this code...
          MyActions[1].Add( (ButtonEventArgs args, FunctionEntry entry) =>
             {
                if (args.Button == ItemType.SendAutoButton)
                { 
                    entry.SetParameter("ANDealerPrice", -1); 
                    entry.SetParameter("ANAutoUpdate", 4); 
                }
            } );
          // And so on
    }
