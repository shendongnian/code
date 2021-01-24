        private GameBoard gameBoard = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (gameBoard == null || gameBoard.IsDisposed)
            {
                gameBoard = new GameBoard();
                gameBoard.Show();
            }
            else
            {
                gameBoard.Close();
                gameBoard = null;
            }
        }
