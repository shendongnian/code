     private void button1_MouseMove(object sender, MouseEventArgs e) {
          if (clicked) {
            Point p = new Point(); //in form coordinates
            p.X = e.X + button1.Left - (button1.Width/2);
            p.Y = e.Y + button1.Top - (button1.Height/2);
            button1.Left = p.X;
            button1.Top = p.Y;
          }
        }
