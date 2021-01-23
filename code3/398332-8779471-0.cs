    public partial class Form1 : Form {
      private List<TipRect> _Tips = new List<TipRect>();
      private TipRect _LastTip;
      private ToolTip _tooltip = new ToolTip();
      public Form1() {
        InitializeComponent();
        _Tips.Add(new TipRect(new Rectangle(32, 32, 32, 32), "Tip #1"));
        _Tips.Add(new TipRect(new Rectangle(100, 100, 32, 32), "Tip #2"));
      }
      private void Form1_Paint(object sender, PaintEventArgs e) {
        foreach (TipRect tr in _Tips)
          e.Graphics.FillRectangle(Brushes.Red, tr.Rect);
      }
      private void Form1_MouseMove(object sender, MouseEventArgs e) {
        TipRect checkTip = GetTip(e.Location);
        if (checkTip == null) {
          _LastTip = null;
          _tooltip.Hide(this);
        } else {
          if (checkTip != _LastTip) {
            _LastTip = checkTip;
            _tooltip.Show(checkTip.Text, this, e.Location.X + 10, e.Location.Y + 10, 1000);
          }
        }
      }
      private TipRect GetTip(Point p) {
        TipRect value = null;
        foreach (TipRect tr in _Tips) {
          if (tr.Rect.Contains(p))
            value = tr;
        }
        return value;
      }
    }
