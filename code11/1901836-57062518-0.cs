    var connectionString = "Hard code connection string";
    //Make sure your DataContext has a constructor that takes in a connection string
    using (var context = new DataContext(connectionString)) 
      {
        context.Macros.Add(new Macro { Name = "test" });                    
        context.SaveChanges();
        //Output to the screen if the savechanges was successful
        new Decider().Decide(EnumDecisionType.eOkDecision, "Save Changes Called ", "", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
      }
    
