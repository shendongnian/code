     public class MyGameService : IGameService
     {
           public PlayerPosition[] GetPlayerPositions()
           {
               return GameState.Instance.GetPlayerPositions();
           }
     }
