    private void listBox1_MouseMove(object sender, MouseEventArgs e)
    {
    
        if (e.X > listBox1.Width - 1 || e.Y > listBox1.Height - 1 || e.X < 0 || e.Y < 0) 
        {
            Console.WriteLine("drag out");
        }
        else
            Console.WriteLine("mouse move {0}/{1}", e.X, e.Y);
    }
