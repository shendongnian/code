public partial class MainWindow : Window
{
    private Canvas can = new Canvas() { Background = Brushes.White };
    private Grid grid = new Grid() { Height = 150, Width = 100, Background = Brushes.Yellow };
    private TextBlock textBlock = new TextBlock() { Text = "TextBlock Text", FontWeight = FontWeights.Bold };
    private Point point = new Point();
    public MainWindow()
    {
        InitializeComponent();
        grid.Children.Add(textBlock);
        can.Children.Add(grid);
        Canvas.SetLeft(grid, 0);
        Canvas.SetTop(grid, 0);
        textBlock.PreviewMouseDown += TextBlock_PreviewMouseDown;
        textBlock.PreviewTouchDown += TextBlock_PreviewTouchDown;
        textBlock.MouseUp += TextBlock_MouseUp;
        textBlock.TouchUp += TextBlock_TouchUp;
        can.PreviewMouseMove += Can_PreviewMouseMove;
        can.PreviewTouchMove += Can_PreviewTouchMove;
        RootGrid.Children.Add(can);
    }
    private void TextBlock_PreviewTouchDown(object sender, TouchEventArgs e)
    {
        point = e.GetTouchPoint(grid).Position;
        e.TouchDevice.Capture(textBlock);
    }
    private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        point = e.GetPosition(grid);
        e.MouseDevice.Capture(textBlock);
    }
    private void TextBlock_TouchUp(object sender, TouchEventArgs e)
    {
        e.TouchDevice.Capture(null);
    }
    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
        e.MouseDevice.Capture(null);
    }
    private void Can_PreviewTouchMove(object sender, TouchEventArgs e)
    {
        if (e.OriginalSource is TextBlock)
        {
            Canvas.SetLeft(grid, e.GetTouchPoint(this).Position.X - point.X);
            Canvas.SetTop(grid, e.GetTouchPoint(this).Position.Y - point.Y);
        }
    }
    private void Can_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (e.OriginalSource is TextBlock && e.LeftButton == MouseButtonState.Pressed && e.StylusDevice == null)
        {
            Canvas.SetLeft(grid, e.GetPosition(this).X - point.X);
            Canvas.SetTop(grid, e.GetPosition(this).Y - point.Y);
        }
    }
}
I hope this is helpful.
