    int moveCount = 0;
    ToolTip toolTip = new ToolTip();
    private void form1_MouseMove(object sender, MouseEventArgs e)
    {
        Trace.WriteLine(moveCount);
        moveCount++;
        toolTip.SetToolTip(this, "Hello world");
    }
