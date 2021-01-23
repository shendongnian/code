            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.0;
            animation.To = 1.0;
            animation.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation.AutoReverse = false;
            DoubleAnimation animation2 = new DoubleAnimation();
            animation2.From = 1.0;
            animation2.To = 0.0;
            animation2.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation2.AutoReverse = false;
            DoubleAnimation animation3 = new DoubleAnimation();
            animation3.From = 0.0;
            animation3.To = 1.0;
            animation3.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation3.AutoReverse = false;
            Storyboard storyboard = new Storyboard();
            storyboard.AutoReverse = true;
            storyboard.Children.Add(animation);
            Storyboard.SetTargetName(animation, boxSmall.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Viewbox.OpacityProperty));
            storyboard.Children.Add(animation2);
            Storyboard.SetTargetName(animation2, box.Name);
            Storyboard.SetTargetProperty(animation2, new PropertyPath(Viewbox.OpacityProperty));
            storyboard.Children.Add(animation3);
            Storyboard.SetTargetName(animation3, border.Name);
            Storyboard.SetTargetProperty(animation3, new PropertyPath(Rectangle.OpacityProperty));
            svi.SizeChanged += delegate(object s, SizeChangedEventArgs args)
            {
                if (args.NewSize.Width < 150 && args.NewSize.Height < 150 && !isSmall)
                {
                    svi.CanScale = false;
                    storyboard.Completed += (o, s) =>
                    {
                        Console.WriteLine("Storyboard completed");
                        svi.CanScale = true;
                    };
                    storyboard.Begin(this);
                    isSmall = true;
                }
                if (args.NewSize.Width > 150 && args.NewSize.Height > 150 && isSmall)
                {
                    isSmall = false;
                }
            };
