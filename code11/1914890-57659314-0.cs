    public MainWindow()
    {
        InitializeComponent();
    
        double maxWidth = 250;
        double maxHeight = 250;
    
        double yourWidth = 800; // INPUT
        double yourHeight = 100; // INPUT
    
        Rectangle rect = new Rectangle();
        SolidColorBrush colorbrush = new SolidColorBrush();
        colorbrush.Color = Colors.SteelBlue;
        rect.Fill = colorbrush;
    
        double ratioX = yourWidth / maxWidth;
    
        var newWidth = maxWidth;
        var newHeight = yourHeight / ratioX;
    
        if (newHeight > maxHeight) Console.WriteLine("Height is too long...");
    
        rect.Width = newWidth;
        rect.Height = newHeight;
    
        Main.Children.Add(rect);
    }
