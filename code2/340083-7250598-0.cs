    using System;
    using System.Linq;
    using System.Drawing;
    using System.IO;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var gen = new RandomIconGenerator(32);
            var dir = new DirectoryInfo(@"C:\RandIcons\");
            if (!dir.Exists) dir.Create();
            for (int it = 0; it < 1000; it++)
                using (var s = new FileStream(@"C:\RandIcons\" + "icon-" + it + ".ico", FileMode.Create))
                    gen.MakeRandomIcon().Save(s);
        }
    }
    /// <summary>
    /// Generates random icons using various colored shapes and lines, using available brushes and pens.
    /// </summary>
    public class RandomIconGenerator
    {
        Random r = new Random();
        Pen[] pens = typeof(Pens).GetProperties().Select(p => (Pen)p.GetValue(null, null)).ToArray();
        Brush[] brushes = typeof(Brushes).GetProperties().Select(p => (Brush)p.GetValue(null, null)).ToArray();
        int size;
        public RandomIconGenerator(int size) { this.size = size; }
        public Icon MakeRandomIcon()
        {
            using (Bitmap bmp = new Bitmap(size, size))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int it = 0; it < 20; it++) this.GetRandomPainter()(g);
                g.Flush();
                return Icon.FromHandle(bmp.GetHicon());
            }
        }
        private Pen GetRandomPen() { return this.pens[this.r.Next(this.pens.Length)]; }
        private Brush GetRandomBrush() { return this.brushes[this.r.Next(this.brushes.Length)]; }
        private Action<Graphics> GetRandomPainter()
        {
            switch (r.Next(5))
            {
                case 0: return g => g.DrawLine(this.GetRandomPen(), this.GetRandomPoint(), this.GetRandomPoint());
                case 1: return g => g.DrawRectangle(this.GetRandomPen(), this.GetRandomRect());
                case 2: return g => g.DrawEllipse(this.GetRandomPen(), this.GetRandomRect());
                case 3: return g => g.FillRectangle(this.GetRandomBrush(), this.GetRandomRect());
                case 4: return g => g.FillEllipse(this.GetRandomBrush(), this.GetRandomRect());
                default: throw new Exception();
            }
        }
        private Rectangle GetRandomRect()
        {
            var p0 = this.GetRandomPoint();
            return new Rectangle(p0, new Size(this.GetRandomPoint()) - new Size(p0));
        }
        private int GetRandomPos() { return this.r.Next(this.size); }
        private Point GetRandomPoint() { return new Point(this.GetRandomPos(), this.GetRandomPos()); }
    }
