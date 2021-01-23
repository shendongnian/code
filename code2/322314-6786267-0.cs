    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        //replay is an array of the chess moves that were made since the start of the game.
        foreach (KeyValuePair<int, int[]> item in replay)// count should be more than 2
        {
             if (!backgroundWorker1.CancellationPending)
             {
                  // ...
                  uiCtx.Post(o =>
                  {
                      PrintPieces(codeFile.PieceState());
                  ), null);
                  System.Threading.Thread.Sleep(1000);
             }
             else
             {
                  break;
             }
            
         }
     }
