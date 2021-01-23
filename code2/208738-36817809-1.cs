    public override System.Drawing.Color BackColor
    {
        get
        {
            if (box == null) { return Color.White; }
            System.Windows.Media.Brush br = box.Background;
            byte a = ((System.Windows.Media.SolidColorBrush)(br)).Color.A;
            byte g = ((System.Windows.Media.SolidColorBrush)(br)).Color.G;
            byte r = ((System.Windows.Media.SolidColorBrush)(br)).Color.R;
            byte b = ((System.Windows.Media.SolidColorBrush)(br)).Color.B;
            return System.Drawing.Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
        set 
        {
            box.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B));
        }
    }
