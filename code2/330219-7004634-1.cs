    this.Timer = new System.Windows.Threading.DispatcherTimer
    {
        Interval = new TimeSpan(0, 0, 1)
    };
    this.Timer.Tick += (s, e) =>
    {
        var _Control = s as MyFirstControl;
        var _Other = LogicalTreeHelper.GetChildren(_Control.Parent)
            .Cast<FrameworkElement>().Where(x => x.Name == "FindIt")
            .First<MySecondControl>();
        _Other.DoMethod();
    };
