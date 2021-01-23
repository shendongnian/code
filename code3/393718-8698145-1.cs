    public partial class MainPage : UserControl
    {
        private Chart chart_;
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var data = new List<Point>(100);
            for (int i = 0; i < 100; i++)
            {
                data.Add(new Point(i, Math.Sin(i * Math.PI / 50)));
            }
            chart_ = new Chart()
            {
                Name = "Chart",
                Width = 512,
                Height = 512
            };
            LineSeries line = new LineSeries()
            {
                Name = "Line",
                Title = "test",
                IndependentValuePath = "X",
                DependentValuePath = "Y",
                ItemsSource = data
            };
            chart_.Series.Add(line);
            chart_.SetValue(Grid.ColumnProperty, 0);
            grdGraphs.Children.Add(chart_);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = new WriteableBitmap((int)(chart_.RenderSize.Width), (int)(chart_.RenderSize.Height));
            bitmap.Render(chart_, new MatrixTransform());
            bitmap.Invalidate();
            img.Source = bitmap;
        }
    }
