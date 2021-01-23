    namespace Chess
    {
    public class GridSquare : PictureBox
    {
        private int x;
        private int y;
        private static GridSquare lastClicked;
        private static ChessBoard board;
        private ChessPiece piece;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public static ChessBoard Board { set { board = value; } }
        Color LightTile = Color.Beige;
        Color DarkTile = Color.SandyBrown;
        public ChessPiece Piece 
        {
            get { return piece; }
            set 
            {
                piece = value;
                if (value == null)
                    this.BackgroundImage = null;
                else
                    this.BackgroundImage = piece.GetImage();
            }
        }
        public GridSquare(int x, int y)
        {
            int ButtonWidth = 64;
            int ButtonHeight = 64;
            int Distance = 20;
            int start_x = 10;
            int start_y = 10;
            this.x = x;
            this.y = y;
            this.Top = start_x + (x * ButtonHeight + Distance + x);
            this.Left = start_y + (y * ButtonWidth + Distance + y);
            this.Width = ButtonWidth;
            this.Height = ButtonHeight;
            this.Text = "X: " + x.ToString() + " Y: " + y.ToString();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Click += new System.EventHandler(gridSquare_Click);
        }
        private void gridSquare_Click(object sender, EventArgs e)
        {
            GridSquare gs = (GridSquare)sender;
            if (lastClicked != null)
                lastClicked.ResetColour();
            //Change: need to click for change in colour, then second click to revert back
            this.BackColor = Color.LightBlue;
            lastClicked = this;
            if (gs.Piece != null)
            {
                board.StatusLabel.Text = "You clicked a " + gs.Piece.GetName() + " at (" + gs.X + ", " + gs.Y + ")";
            }
            else
            {
                board.StatusLabel.Text = "You clicked (" + gs.X + ", " + gs.Y + ")";
            }
        }
        public void ResetColour()
        {
            if (x % 2 == 0)
                if (y % 2 == 0)
                    // If x=Even y=Even
                    this.BackColor = LightTile;
                else
                    // If x=Even y=Odd
                    this.BackColor = DarkTile;
            else
                if (y % 2 == 0)
                    // If x=Odd y=Even
                    this.BackColor = DarkTile;
                else
                    // If x=Odd y=Odd
                    this.BackColor = LightTile;
        }
    }
}
