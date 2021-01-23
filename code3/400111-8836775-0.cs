    private void UserControl_IsVisibleChanged(object sender, 
        DependencyPropertyChangedEventArgs e)
    {
        if (this.Visibility == Visibility.Visible)
        {
            DoubleAnimation fadeIn = new DoubleAnimation();
            fadeIn.From = 1d;
            fadeIn.To = 1d;
            fadeIn.Duration = new Duration(new TimeSpan(0, 0, 0));
            DoubleAnimation fade = new DoubleAnimation();
            fade.From = 1d;
            fade.To = 0d;
            fade.BeginTime = TimeSpan.FromSeconds(((MessageTextProperties)  
                DataContext).Duration);
            fade.Duration = new Duration(new TimeSpan(0, 0, 1));
            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName(this.Name, this);
            Storyboard.SetTargetName(fadeIn, this.Name);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath
                (UIElement.OpacityProperty));
            Storyboard.SetTargetName(fade, this.Name);
            Storyboard.SetTargetProperty(fade, new PropertyPath
                (UIElement.OpacityProperty));
            Storyboard sb = new Storyboard();
            sb.Children.Add(fadeIn);
            sb.Children.Add(fade);
            sb.Completed += new EventHandler(sb_Completed);
            sb.Begin(this);
        }
    }
    void sb_Completed(object sender, EventArgs e)
    {
        this.Visibility = Visibility.Hidden;
    }
