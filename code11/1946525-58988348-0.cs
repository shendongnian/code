    public void RectangleToThumb()
    {
        Rectangle r = new Rectangle();
        r.Height = 80;
        r.Width = 150;
        r.Fill = new SolidColorBrush(Colors.Red);
        ControlTemplate t = CreateTemplate();
        Thumb th = new Thumb();
        th.Template = t;
        RootGrid.Children.Add(th);
    }
    private static ControlTemplate CreateTemplate()
    {
        const string xaml = "<ControlTemplate TargetType='Thumb' xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Rectangle  Width = '150' Height = '80'  Fill = 'Red' /></ControlTemplate>";
        var сt = (ControlTemplate)XamlReader.Load(xaml);
        return сt;
    }
