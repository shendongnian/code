    void draw_line()
            {
                Pen mypen;
                mypen = new Pen(Color.Black , 1);
                Graphics g = this.CreateGraphics();
                g.DrawLine(mypen, 0, 20, 1000, 20); 
                // 0,20 are starting points and 1000,20 are destination.
                mypen.Dispose();
                g.Dispose();
            }
