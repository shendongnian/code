    private void Form1_Load(object sender, EventArgs e) // On Form Load
    {
        this.WindowState = FormWindowState.Maximized;
        if (this.WindowState == FormWindowState.Maximized)
        {
            maxW = this.Size.Width;
            maxH = this.Size.Height;
        }
        this.WindowState = FormWindowState.Normal;
    }
    private void Form1_Move(object sender, EventArgs e)
    {
        if (maxH != 0 && maxW != 0)
        {
            if (this.Location.Y < 100)
            {
                Point p = new Point(0, 0);
                this.Size = new Size(maxW, 700);
                this.Location = p;
            }
            else if (this.Location.Y > (maxH - 100))
            {
                Point p = new Point(0, (maxH - 700));
                this.Size = new Size(maxW, 700);
                this.Location = p;                
            }
        }     
    }
