     public class MeamWithPlayersViewModel
     {
          public long TeamID { get; set; }
          public string TeamName { get; set; }
          public TeamPlayer[] Players { get; set; }
     }
     public class TeamPlayer
     {
          public long PlayerID { get; set; }
          public string Name { get; set; }
     }
