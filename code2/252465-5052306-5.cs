    public static readonly DependencyProperty ColorSelectedProperty =
            DependencyProperty.Register(
                "ColorSelected", 
                typeof(SolidColorBrush),
                typeof(PenSelector), 
                new PropertyMetadata(new SolidColorBrush(Colors.Yellow)));
        public SolidColorBrush ColorSelected
        {
            get
            {
                return (SolidColorBrush)GetValue(ColorSelectedProperty);
            }
            set
            {
                SetValue(ColorSelectedProperty, value);
            }
        }
        
        public PenSelector()
        {
            InitializeComponent();
            LayoutRoot.Items.Add(addRectangle());
            LayoutRoot.Items.Add(addRectangle());
        }
        private Rectangle addRectangle()
        {
            Rectangle r = new Rectangle() { Width = 160, Height = 80 };
            Binding b = new Binding();
            b.Source=this;
            b.Path=new PropertyPath("ColorSelected");
            b.Mode=BindingMode.OneWay;
            r.SetBinding(Rectangle.FillProperty, b);
            return r;
        }
