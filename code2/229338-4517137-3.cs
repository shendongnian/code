         private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           Pen pen = new Pen(Color.AliceBlue);
            PointF p = new PointF();
         e.Graphics.DrawLine(pen,p.X,p.Y);
        
        }
