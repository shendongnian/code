    class2
    {
      public void ExecuteAll(int rowStart,int columnStart,int rowEnd,int columnEnd)
      {
        ChessBoard chess = new ChessBoard();
        chess.YourTurn();
        counter++;
        PlayerA.Text = chess.PlayerAText;
        PlayerA.Text = chess.PlayerBText;
      }
    }
    public static int counter;
