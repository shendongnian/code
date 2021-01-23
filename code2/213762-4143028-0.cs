    private int difference = 10;
    private int xPosition;
    private int yPosition;
    private void item_MouseDown(object sender, MouseEventArgs e) 
    {
        this.MouseMove += new MouseEventHandler(Form_MouseMove);
        xPosition = e.X;
        yPosition = e.Y;
    }
    private void Form_MouseMove(object sender, MouseEventArgs e) 
    {
        if (e.X < xPosition - difference
            || e.X > xPosition + difference
            || e.Y < yPosition - difference
            || e.Y > yPosition + difference) 
        {
            //Execute "dragdrop" code
            this.MouseMove -= Form_MouseMove;
        }
    }
