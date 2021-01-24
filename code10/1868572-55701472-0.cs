        public MyView()
        {
            InitializeComponent();
            richEditControl1.GotFocus += RichEditControl1OnGotFocus;
            richEditControl2.GotFocus += RichEditControl2OnGotFocus;
            RichEditControl1OnGotFocus(null, null);
        }
        private void RichEditControl1OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            richEditControlProvider1.RichEditControl = richEditControl1;
            richEditControl1.Ribbon = ribbonControl1;
            richEditControl2.Ribbon = null;
            richEditControl1.BarManager = barManager1;
            richEditControl2.BarManager = null;
        }
        private void RichEditControl2OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            richEditControlProvider1.RichEditControl = richEditControl2;
            richEditControl1.Ribbon = null;
            richEditControl2.Ribbon = ribbonControl1;
            richEditControl1.BarManager = null;
            richEditControl2.BarManager = barManager1;
        }
