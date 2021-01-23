        public MainWindow()
        {
            InitializeComponent();
            MyMonths = new List<DateTime>();
            var thisMonth = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                1);
            for (var i = 0; i < 4; i++)
            {
                MyMonths.Add(thisMonth.AddMonths(-i));
            }
            this.DataContext = this;
        }
        public List<DateTime> MyMonths
        {
            get { return (List<DateTime>)GetValue(MyMonthsProperty); }
            set { SetValue(MyMonthsProperty, value); }
        }
        public static readonly DependencyProperty MyMonthsProperty =
            DependencyProperty.Register("MyMonths", typeof(List<DateTime>), typeof(MainWindow), new UIPropertyMetadata(null));      
