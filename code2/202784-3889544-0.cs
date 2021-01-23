    class DecisionQuery : Decision {
      public Decision Positive { get; set; }
      public Decision Negative { get; set; }
      // Primitive operation to be provided by the user
      public Func<Client, bool> Test { get; set; }
      public override bool Evaluate(Client client) {
        // Test a client using the primitive operation
        bool res = Test(client);
        // Select a branch to follow
        return res ? Positive.Evaluate(client) : Negative.Evaluate(client);
      }
    }
