    public partial class MainWindow : Window
    {
        private delegate void LoadDelegate();
        public MainWindow()
        {
            InitializeComponent();
            LoadDelegate oD = Load;
            Dispatcher.BeginInvoke (
                oD,  
                System.Windows.Threading.DispatcherPriority.Loaded, 
                null
            );
        }
        private void Load()
        {
            var items = LogicalTreeHelper
                            .GetChildren(uiGrid)
                            .OfType<Border>()
                            .Select(brd => new { Column = Grid.GetColumn(brd), Row = Grid.GetRow(brd), Item = brd })
                            .ToList();
            Border oStart = items
                                .FirstOrDefault(item => item.Column == 1 && item.Row == 1)
                                .Item;
            Border oStop = items
                                .FirstOrDefault(item => item.Column == 2 && item.Row == 2)
                                .Item;
            Point topLeft = oStart.PointToScreen(new Point(0, 0));
            Point bottomRight = oStop.PointToScreen(new Point(oStop.ActualWidth, oStop.ActualHeight));
            Rectangle oRect = new Rectangle();
            oRect.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            Point oLeft = uiCanvas.PointFromScreen(topLeft);
            Canvas.SetLeft(oRect, oLeft.X);
            Canvas.SetTop(oRect, oLeft.Y);
            oRect.Width = bottomRight.X - topLeft.X;
            oRect.Height = bottomRight.Y - topLeft.Y;
            uiCanvas.Children.Add(oRect);
        }
    }
...
    <Grid>
        <Grid x:Name="uiGrid">
            <Grid.RowDefinitions>
                <RowDefinition />
                <RowDefinition />
                <RowDefinition />
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <Border Background="Red" Grid.Column="1" Grid.Row="1" />
            <Border Background="Red" Grid.Column="2" Grid.Row="2" />
        </Grid>
        
        <Canvas x:Name="uiCanvas" />
    </Grid>
