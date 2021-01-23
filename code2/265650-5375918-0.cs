    SomeMethod(...)
    {
        Timer t = new Timer();
        t.Interval = 1000;
        t.Tick += t_Tick;
        t.Enabled = true;
        t.Start();
    }
    
    void t_Tick(...)
    {
        foreach (KeyValuePair<int, int[]> item in replay)// count should be more than 2
        {           
            makeSelfMoves = replay[item.Key];
            codeFile.ExecuteAll(makeSelfMoves[0], makeSelfMoves[1], makeSelfMoves[2], makeSelfMoves[3]);
            PrintPieces(codeFile.PieceState());
            // MessageBox.Show("rowStart: " + makeSelfMoves[0] + ". rowEnd: " + makeSelfMoves[2] + ". columnStart: " + makeSelfMoves[1] + ". columnEnd: " + makeSelfMoves[3] + "____a is: " + a);
        }
    }
