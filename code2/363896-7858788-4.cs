    namespace GG
    {
        public partial class frmPGame : Form
        {
            public frmPGame()
            {
                GameBoardMath.ClearGameBoard(gameBoard); // Clear the game board
                InitializeComponent();
            }
    
            Piece[,] gameBoard = new Piece[9, 8];    
        }
        public class GameBoardMath
        {
            public static void ClearGameBoard(Piece[,] gameBoard)
            {
                int lenX = gameBoard.GetLength(0);
                int lenY = gameBoard.GetLength(1);
                for (int y = 0; y < lenY; y++)
                {
                    for (int x = 0; x < lenX; x++)
                    {
                        gameBoard[x, y] = new Piece();
                        gameBoard[x, y].rank = -1;
                        gameBoard[x, y].player = 0;
                    }
                }
            }
        }
    }
