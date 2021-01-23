    private void Show()
        {
            MyControl.Visibility = System.Windows.Visibility.Visible;
            var a = new DoubleAnimation
                        {
                            From = 1.0,
                            To = 0.0,
                            FillBehavior= FillBehavior.Stop,
                            BeginTime = TimeSpan.FromSeconds(2),
                            Duration = new Duration(TimeSpan.FromSeconds(0.5))
                        };
            var storyboard = new Storyboard();
            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, MyControl);
            Storyboard.SetTargetProperty(a, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate { MyControl.Visibility = System.Windows.Visibility.Hidden; };
            storyboard.Begin();            
        }
