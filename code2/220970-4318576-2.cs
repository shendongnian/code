    Storyboard storyboard = new Storyboard();
    TimeSpan duration = TimeSpan.FromMilliseconds(500); //
    DoubleAnimation fadeInAnimation = new DoubleAnimation() 
        { From = 0.0, To = 1.0, Duration = new Duration(duration) };
    
    DoubleAnimation fadeOutAnimation = new DoubleAnimation()
        { From = 1.0, To = 0.0, Duration = new Duration(duration) };
    fadeOutAnimation.BeginTime = TimeSpan.FromSeconds(5);
    Storyboard.SetTargetName(fadeInAnimation, element.Name);
    Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
    storyboard.Children.Add(fadeInAnimation);
    storyboard.Begin(element);
    Storyboard.SetTargetName(fadeOutAnimation, element.Name);
    Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity", 0));
    storyboard.Children.Add(fadeOutAnimation);
    storyboard.Begin(element);
