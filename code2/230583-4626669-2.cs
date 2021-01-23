            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                GraphicsPath g = new GraphicsPath();
                g.AddRectangle(new Rectangle(0, 0, 200, 200));
                g.AddEllipse(50, 50, 100, 100);
    
                //Original path
                e.Graphics.DrawPath(new Pen(Color.Black,2), g);
    
                //"Inset" path
                g.Widen(new Pen(Color.Black, 10));
                e.Graphics.DrawPath(new Pen(Color.Red, 2), g);
            }
