    var animation1 = new DoubleAnimation
    {
        To = 0.0,
        Duration = TimeSpan.FromSeconds(5),
        FillBehavior = FillBehavior.HoldEnd
    };
    var animation2 = new DoubleAnimation
    {
        To = 0.0,
        Duration = TimeSpan.FromSeconds(5),
        FillBehavior = FillBehavior.HoldEnd
    };
    Storyboard.SetTarget(animation1, element1);
    Storyboard.SetTargetProperty(animation1, "Opacity");
    Storyboard.SetTarget(animation2, element2);
    Storyboard.SetTargetProperty(animation2, "Opacity");
    Storyboard story = new Storyboard();
    story.Children.Add(animation1);
    story.Children.Add(animation2);        
    story.Begin();
