        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red, 2);      
            Rectangle Fig1 = new Rectangle(50, 50, 100, 50);  //dimensions of Fig1
            Rectangle Fig2 = new Rectangle(100, 50, 100, 50); //dimensions of Fig2
            . . .
            DrawFigure(e.Graphics, p, Fig1);   
            DrawFigure(e.Graphics, p, Fig2);
            . . .
            //remember to call  FillFigure after  drawing all figures.
            FillFigure(e.Graphics, p, Fig1); 
            FillFigure(e.Graphics, p, Fig2);
            . . .
        }
        private void DrawFigure(Graphics g, Pen p, Rectangle r)
        {
            g.DrawEllipse(p, r.X, r.Y, r.Width, r.Height);
        }
        private void FillFigure(Graphics g, Pen p, Rectangle r)
        {
            g.FillEllipse(new SolidBrush(this.BackColor), r.X + p.Width, r.Y + p.Width, r.Width - 2 * +p.Width, r.Height - 2 * +p.Width);      //Adjusting Color so that it will leave border and fill 
        }
