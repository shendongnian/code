    Rectangle MyRectangle;
    private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        // Create a local version of the graphics object for the PictureBox.
        Graphics g = e.Graphics;
    
        g.DrawRectangle(Pens.Black, MyRectangle);
    }
