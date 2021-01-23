    void UControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    Storyboard sb = new Storyboard();
                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 0;
                    da.To = 1;
                    da.Duration = new Duration(TimeSpan.FromSeconds(2));
                    sb.Children.Add(da);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UserControl.OpacityProperty));
                    Storyboard.SetTarget(da, this);
                    sb.Completed += new EventHandler(sb_Completed);
                    sb.Begin();
                }
    
                if (this.Visibility == Visibility.Hidden || this.Visibility == Visibility.Collapsed)
                {
                    Storyboard sb = new Storyboard();
                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 1;
                    da.To = 0;
                    da.Duration = new Duration(TimeSpan.FromSeconds(2));
                    sb.Children.Add(da);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UserControl.OpacityProperty));
                    Storyboard.SetTarget(da, this);
                    sb.Completed += new EventHandler(sb_Completed);
                    sb.Begin();
                }
            }
    
            void sb_Completed(object sender, EventArgs e)
            {
                this.Visibility = Visibility.Visible;
            }
