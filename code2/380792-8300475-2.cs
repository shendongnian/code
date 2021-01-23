    public class Pasta : Control
    {
        int a;
        int b;
        int c;
        public void PastaCiz(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            float toplam = a + b + c;
            float deg1 = (a / toplam) * 360;
            float deg2 = (b / toplam) * 360;
            float deg3 = (c / toplam) * 360;
            Pen p = new Pen(Color.Red, 2);
            Graphics g = e.Graphics;                           <-- note
            Rectangle rec = new Rectangle(50, 12, 150, 150);
            Brush b1 = new SolidBrush(Color.Red);
            Brush b2 = new SolidBrush(Color.Black);
            Brush b3 = new SolidBrush(Color.Blue);
            Brush b4 = new SolidBrush(Color.Yellow);
            g.DrawPie(p, rec, 0, deg1);
            g.FillPie(b1, rec, 0, deg1);
            g.DrawPie(p, rec, deg1, deg2);
            g.FillPie(b2, rec, deg1, deg2);
            g.DrawPie(p, rec, deg2 + deg1, deg3);
            g.FillPie(b3, rec, deg2 + deg1, deg3);
        }
    }
