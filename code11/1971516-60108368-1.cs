public class Boat
{
       // This class is made for storing the meta-data of each individual boat
      // Determines the start point 
      public int[,] pos = new int[xBoardSize, yBoardSize];           
      // Determines the direction of the boat (0 = horizontal, 1 = vertical)
      public int direction = 0;
      // Keeps track of the boat's size
      public int length = 1;
      // Keeps track if tile is hit or untouched
      public int[] stateList;
}
Your boats should now be made part of your Board with a `Has-A` relationship:
public class Board
    {
         private Boat[] boats;
         public Board(Boat[] boats) {
             // initialize th boats for the specific game
             this.boats = boats
         }
         Boat SearchForBoat (Vector2 coords)
         {
             foreach (Boat boat in boats)
             {
                 for (int i = 0; i < boat.length; i++)
             }
         }
    
          // These variables determine the size of the board
        int xBoardSize = 10;
        int yBoardSize = 10;
}
Then you need to initialize via a constructor and use the specific instances 
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
