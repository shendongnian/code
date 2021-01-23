    public class GameBoard
    {
        public readonly Piece[,] Board;
        public GameBoard(int x, int y)
        {
            Board = new Piece[x, y];
            ClearGameBoard();
        }
        public void ClearGameBoard()
        {
            int lenX = Board.GetLength(0);
            int lenY = Board.GetLength(1);
            for (int y = 0; y < lenY; y++)
            {
                for (int x = 0; x < lenX; x++)
                {
                    Board[x, y] = new Piece();
                    Board[x, y].rank = -1;
                    Board[x, y].player = 0;
                }
            }
        }
    }
