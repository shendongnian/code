    // Section 8.4.2 Decision trees in C#
    // Listing 8.15 Object oriented decision tree (C#)
    
    abstract class Decision {
      // Tests the given client 
      public abstract void Evaluate(Client client);
    }
    class DecisionResult : Decision {
      public bool Result { get; set; }
      public override void Evaluate(Client client) {
        // Print the final result
        Console.WriteLine("OFFER A LOAN: {0}", Result ? "YES" : "NO");
      }
    }
    // Listing 8.16 Simplified implementation of Template method
    class DecisionQuery : Decision {
      public string Title { get; set; }
      public Decision Positive { get; set; }
      public Decision Negative { get; set; }
      // Primitive operation to be provided by the user
      public Func<Client, bool> Test { get; set; }
      public override void Evaluate(Client client) {
        // Test a client using the primitive operation
        bool res = Test(client);
        Console.WriteLine("  - {0}? {1}", Title, res ? "yes" : "no");
        // Select a branch to follow
        if (res) Positive.Evaluate(client);
        else Negative.Evaluate(client);
      }
    }
    static void MainDecisionTrees()
    {
      // The tree is constructed from a query
      var tree =
          new DecisionQuery
          {
            Title = "More than $40k",
            // Test is specified using a lambda function
            Test = (client) => client.Income > 40000,
            // Sub-trees can be 'DecisionResult' or 'DecisionQuery'
            Positive = new DecisionResult { Result = true },
            Negative = new DecisionResult { Result = false }
          };
    
      // Test a client using this tree
      // Create client using object initializer
      var john = new Client {
          Name = "John Doe", Income = 40000, YearsInJob = 1,
          UsesCreditCard = true, CriminalRecord = false 
        };
      tree.Evaluate(john);
    }
    private static void Main(string[] args)
    {
      MainDecisionTrees();
    }
