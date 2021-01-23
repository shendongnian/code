    class ChessTile
    {
        //Set the bounds an image/vector can move.
        public int X;
        public int Y;
    
        public ChessTile(int x, int y)
        {
            // TODO: Complete member initialization
            this.X = x;
            this.Y = y;
        }
    }
    
    abstract class ChessPiece
    {
        public object Image;//If you want one.
    
        public List<ChessTile> listPositions;//List of possible positions to be calculated during runtime
    
        public enum PieceType { King, Pawn, SomeOtherType }//Types of chess peice.
        public enum Moveable { Up, Down, Left, Right, TopLeft } //Possible positions to move
    
        protected PieceType Type;
        protected Moveable Directions;
    
        public abstract void PossiblePositions(ChessTile CurrentPosition);
    }
    
    //Chess pieces.
    class King : ChessPiece
    {
        public King()
        {
            base.Directions = Moveable.Down | Moveable.Left | Moveable.Right;
            base.Type = PieceType.King;
        }
    
        public override void PossiblePositions(ChessTile CurrentPosition)
        {
            //Calculate position and add to list.
            listPositions.Add(new ChessTile(CurrentPosition.X - 1, CurrentPosition.Y));
        }
    
    }
