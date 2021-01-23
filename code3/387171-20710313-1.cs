    int moveCount = 0;
    private void form1_MouseMove(object sender, MouseEventArgs e)
    {
        Trace.WriteLine(moveCount);
        moveCount++;
    }
