    public class KingPiece: ChessPiece {
      public static readonly BlackKing = new KingPiece(/* image of the black king here */, ChessColor.Black);
      public static readonly WhiteKing = new KingPiece(/* image of the white king here */, ChessColor.White);
    
      // Constructor could also be made private since you probably don't need other instances beside black and white.
      public KingPiece(Image image, ChessColor color): base(image, color) {
        ...
      }
    }
