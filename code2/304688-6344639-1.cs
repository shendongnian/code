     public class MeamWithPlayersViewModel
     {
          public long ID { get; set; }  // this ought to match the id parameter on the post
          public string Name { get; set; }
          public TeamPlayer[] Players { get; set; }
     }
     public class TeamPlayer
     {
          public long PlayerID { get; set; }
          public string Name { get; set; }
     }
