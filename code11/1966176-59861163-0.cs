    class Floor
    {
        public static Floor SharedInstance;
        public int x, y;
        public int w = 700;
        public int h = 5;
        public Canvas c;
    
        public Rectangle _F = new Rectangle();
        public SolidColorBrush CF1 = new SolidColorBrush();
    
        public Floor(Canvas c, int x, int y)
        {
            SharedInstance = this;
            this.x = x;
            this.y = y;
            this.c = c;
    
            CF1.Color = Color.FromRgb(0, 255, 0);
    
            _F.Width = w;
            _F.Height = h;
            _F.Fill = CF1;
            Canvas.SetTop(_F, y); //195
            Canvas.SetLeft(_F, x); // 0
    
            c.Children.Add(_F);
        }
    
        public void Clear()
        {
            c.Children.Remove(_F);
        }
    }
