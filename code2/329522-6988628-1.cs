    MyStoryboards.Animations a = new MyStoryboards.Animations();
    // set the ease function
    BounceEase b = new BounceEase();
    b.Bounces = 5;
    b.Bounciness = 1;
    b.EasingMode = EasingMode.EaseIn;
    a.animThickness(tv, FrameworkElement.MarginProperty, tv.Margin, new Thickness(), TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(5), b);
...
...
    public void animThickness(DependencyObject target, DependencyProperty property, Thickness from, Thickness to, TimeSpan beginTime, TimeSpan duration , IEasingFunction e)
    {
        ThicknessAnimation animation = new ThicknessAnimation();
        animation.To = to;   // final value
        animation.From = from;
        animation.BeginTime = beginTime;
        animation.Duration = duration;
        
        animation.EasingFunction = e;
        //start animating
        Storyboard.SetTarget(animation, target);  // what object will be animated?
        Storyboard.SetTargetProperty(animation, new PropertyPath(property)); // what property will be animated
        Storyboard sb = new Storyboard();
        sb.Children.Add(animation);
        sb.Begin();
    }
