    using System.Net.Sockets;
    
    private List<Point> lstPoints;
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e) 
    {
        if (e.Button == MouseButtons.Left)
        {
            lstPoints = new List<Point>();
            lstPoints.Add(new Point(e.X, e.Y));
        }
    }
    
    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            lstPoints.Add(new Point(e.X, e.Y));
        }
    }
    
    private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        lstPoints.Add(new Point(e.X, e.Y));
    
        StringBuilder sb = new StringBuilder();
    
        foreach (Point obj in lstPoints)
        {
            sb.Append(Convert.ToString(obj) + ":");
        }
    
        serverSocket.Send("MDRAWEVENT" + sb.ToString() + Environment.NewLine);
    }
