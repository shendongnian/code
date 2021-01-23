    Point startPoint = new Point();
    bool dragging = false;
    
    int testOne = 30;
    int testTwo = 30;
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (dragging)
        {
            int diffX = (pictureBox1.PointToClient(e.Location).X - startPoint.X);
            int diffY = (pictureBox1.PointToClient(e.Location).Y - startPoint.Y);
    
            label9.Text = diffX.ToString();   //Works, shows desired result
            label10.Text = diffY.ToString();  //also works fine
    
            testOne = (testOne + diffX); //Issue here
            testTwo = (testTwo + diffY); //and here
    
            label11.Text = (testOne).ToString(); //Unexpected results output
            label12.Text = (testTwo).ToString(); 
        }
    }
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (!dragging) //Incase the mouse down was repeating, it's not
        {
            startPoint = pictureBox1.PointToClient(e.Location);
            dragging = true;
        }
    }
    
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (dragging)
            dragging = false;
    }
