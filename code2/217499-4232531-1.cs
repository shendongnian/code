    internal void Configure(ButtonEventArgs args, IBroker broker, FunctionEntry entry)  
    {
          foreach(var action in MyActions)
          {
               action(args, broker, entry);
          }  
     }
    internal void PopulateMyActions()
    {
          // Hopefully I have not made a syntax error in this code...
          MyActions.Add( (ButtonEventArgs args, IBroker broker, FunctionEntry entry) =>
             {
                if (broker.TradingPhase == 1) 
                {                               
                    if (args.Button == ItemType.SendAutoButton)
                    { 
                        entry.SetParameter("ANDealerPrice", -1); 
                        entry.SetParameter("ANAutoUpdate", 4); 
                    }
                }
            } );
          // And so on
    }
