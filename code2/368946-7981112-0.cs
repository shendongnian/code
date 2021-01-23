    public class team
    {
      public int ID {get;set;}
      public int TotalPlayers{get{return registeredplayers.Count();}}
      public System.Collections.Generic.List<registeredplayers> registeredplayers{get;set;}
    }
