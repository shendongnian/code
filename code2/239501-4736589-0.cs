    foreach (MapLocation loc in e.Result)
    {
        MapLocation copy = loc;
        testDict[loc.ElemId] = loc.ToString();
        this.Dispatcher.BeginInvoke(delegate()
        {
            Image icon = new Image();
            icon.SetValue(Image.SourceProperty, nurseIconSource);
            Canvas.SetLeft(icon, (double)copy.X * MAP_SCALE);
            Canvas.SetTop(icon, MAP_HEIGHT - (double)copy.Y * MAP_SCALE);
            icons[copy.ElemId] = icon;
            MainCanvas.Children.Add(icon);
        });
    }
