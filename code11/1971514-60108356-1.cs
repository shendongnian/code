    public class Board
    {
       // These variables determine the size of the board
       public const int XBoardSize = 10;
       public const int YBoardSize = 10;
       // a board has an array of boats, seems logical
       public Boat[] Boats { get; set; }
    
       // a board can find boats on it
       public Boat SearchForBoat(Vector2 coords )
       {
          foreach (var boat in Boats)
          {
             for (int i = 0; i < boat.Length; i++)
                /// do stuff here
          }
       }
    }
    
    // concrete boat class, which you can make instances from 
    public class Boat
    {
       // notice not static, we are saying an individual "boat" can have these properties
       public int[,] Pos = new int[Board.XBoardSize, Board.YBoardSize];
       public int Direction { get; set; }
       public int Length { get; set; } = 1;
       public int[] StateList { get; set; }
    
    }
