    abstract class Game {
       protected GamePiece _piece;
       protected Game(GamePiece piece)
       {
           _piece = piece;
          // do the common work with pieces here
       }
    }
    class Checkers : Game 
    {
       public Checkers(Checker piece) : base(piece)
       {
         // piece-specific work here
       }
    }
