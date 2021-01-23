    private void redraw()
    {
        wrong++;
        Graphics g = CreateGraphics();
        Brush b=new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.Cross,Color.White,Color.Black);
        if (wrong == 1) g.FillEllipse(b, 250, 125, 30, 30);
    }
