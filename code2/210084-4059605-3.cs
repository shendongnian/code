    //Class that contains the position of the Piece over the Tile
    class PiecePosition
    {
        //Set the bounds an image/vector can move.
        public int X, Y;
    
        public PiecePosition(int x, int y) { this.X = x; this.Y = y; }
        public PiecePosition(int x, int y, int width, int height) { this.X = x; this.Y = y; }
    }
    
    //Base ChessPeice class that shall be used to drive all types of chess pieces.
    //Sixteen pieces: one king, one queen, two rooks, two knights, two bishops, and eight pawns
    //http://en.wikipedia.org/wiki/Chess
    abstract class ChessPiece
    {
        public object Image;//This is an "optional" object that contains the Picture of the Peice, 
        //alternatively, it may contain vector of the image that you want 
        //to draw. Right now this is object is here just for the sake of 
        //understanding that you can use this object here to Draw() it
        //based upon its position.
    
        //Possible movements of the unhindered piece=8
        protected const int MaxDirectionsCount = 8;
    
        public enum PieceType { King, Pawn, SomeOtherType }//Types of chess peice.
        public enum Moves { Up, Down, Left, Right, TopLeft, Etc }//Possible positions a piece can move
    
        protected PieceType Type; //Contains type of piece
        protected Moves MoveableDirections;//Shall contain the allowable directions
    
        public List<PiecePosition> listPositions;//List of possible positions to be calculated during runtime
    
        //Defines a piece can skip
        protected int SkippableBlocks;
    
        public abstract void PossiblePositions(PiecePosition CurrentPosition);//Calculates possible positions
        public abstract void Draw();//Draws the piece
    
    }
    
    //The King Chess piece
    //http://en.wikipedia.org/wiki/King_%28chess%29
    class King : ChessPiece
    {
        //Constructor that sets the type of piece
        public King()
        {
            //Set the directions a King can move.
            base.MoveableDirections = Moves.Down | Moves.Left | Moves.Right;
            base.Type = PieceType.King;
            SkippableBlocks = 1; //Max a king can move is one block in the base.Directions set above.
    
        }
    
        //Calculates possible available positions to move to, during runtime; based upon current position.
        public override void PossiblePositions(PiecePosition CurrentPosition)
        {
            //Calculate position
            //Since you know this is king piece, you can calculate the possible positions
            //And add that the list of possible positions.
            //For instance, a King can move 
            int X = 0; int Y = 0;
            for (int i = 0; i < MaxDirectionsCount; i++)
            {
                //Calculate directions.
                if (base.MoveableDirections == Moves.Down) { X = CurrentPosition.X - 1; Y = CurrentPosition.Y; }
                if (base.MoveableDirections == Moves.Up) { X = CurrentPosition.X + 1; Y = CurrentPosition.Y; }
    
                //Rest of the directions go here...
                //...Btw, what would you do for cross directions? 
                //One way could be to pass a Rectangle in the ChessTile(x,y,width,height) constructor
    
                //Add to list of possible directions.
                listPositions.Add(new PiecePosition(X, Y));
    
            }
        }
    
        public override void Draw()
        {
            //You can actually draw/redraw using the Image object
            //based upon the current/moved position.
        }
    
    
    
    }
