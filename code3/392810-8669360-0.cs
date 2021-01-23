    var storyboard = new Storyboard();
    
    var opacityAnimation = new DoubleAnimation { 
        From = 0,
        To = 1,
        Duration = DurationHelper.FromTimeSpan(TimeSpan.FromSeconds(1)),
    };
    storyboard.Children.Add(opacityAnimation);
    
    Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
    Storyboard.SetTarget(storyboard, myObject);
    
    storyboard.Begin();
