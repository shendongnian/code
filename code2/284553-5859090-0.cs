    DoubleAnimation dbAscending = new DoubleAnimation(0, 15, new Duration(TimeSpan.FromMilliseconds(300)));
    Storyboard storyboard = new Storyboard();
    storyboard.Children.Add(dbAscending);
    Storyboard.SetTarget(dbAscending, myImage);
    Storyboard.SetTargetProperty(dbAscending, new PropertyPath("RenderTransform.Angle"));
