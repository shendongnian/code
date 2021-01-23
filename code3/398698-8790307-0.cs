    public partial class Form1 : Form {
      private Point _StartPoint;
      private List<Rectangle> _Ovals = new List<Rectangle>();
      public Form1() {
        InitializeComponent();
        this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        this.MouseUp += new MouseEventHandler(Form1_MouseUp);
        this.Paint += new PaintEventHandler(Form1_Paint);
      }
      void Form1_Paint(object sender, PaintEventArgs e) {
        foreach (Rectangle r in _Ovals)
          e.Graphics.FillEllipse(Brushes.Red, r);
      }
      void Form1_MouseDown(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left)
          _StartPoint = e.Location;
      }
      void Form1_MouseUp(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
          _Ovals.Add(MakeRectangle(_StartPoint, e.Location));
          this.Invalidate();
        }
      }
      private Rectangle MakeRectangle(Point p1, Point p2) {
        int x = (p1.X < p2.X ? p1.X : p2.X);
        int y = (p1.Y < p2.Y ? p1.Y : p2.Y);
        int w = Math.Abs(p1.X - p2.X);
        int h = Math.Abs(p1.Y - p2.Y);
        return new Rectangle(x, y, w, h);
      }
    }
