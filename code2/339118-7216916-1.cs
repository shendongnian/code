    int mouseDown = 0;
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseDown == 0)
            return;
        Console.WriteLine("e.X: {0}, e.Y: {1}", e.X, e.Y);
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        mouseDown++;
    }
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        mouseDown--;
    }
