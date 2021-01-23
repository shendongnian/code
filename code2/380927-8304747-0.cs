    public class State
    {
      public int StateId {get;set;}
      public string StateName {get;set;}
    }
    
    public class LookupContext : DbContext
    {
      public DbSet<State> States {get;set;}
      // ... more lookups as DbSets
    }
