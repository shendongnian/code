    bool mouseDown = false;
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!mouseDown)
            return;
        Console.WriteLine("e.X: {0}, e.Y: {1}", e.X, e.Y);
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            mouseDown = true;
    }
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            mouseDown = false;
    }
