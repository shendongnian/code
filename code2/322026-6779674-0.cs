    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        int[] makeSelfMoves = new int[4];
        {
            lock (replay)
            {
                foreach (KeyValuePair<int, int[]> item in replay)// count should be more than 2
                {
                    makeSelfMoves = replay[item.Key];
                    codeFile.ExecuteAll(makeSelfMoves[0], makeSelfMoves[1], makeSelfMoves[2], makeSelfMoves[3]);
                    PrintPieces(codeFile.PieceState());
                    if (backgroundWorker1.CancellationPending)
                        break;
                    System.Threading.Thread.Sleep(1000);
                }
                Class2.counter = serializeMeh.serializedCounter;
                Class2.replayIsOn = false;
                Game.WasntSerialized = true;
            }
        }
    }
