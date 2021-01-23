    private void _resizeButton_Click(object sender, RoutedEventArgs e)
    {
        double currentHeight = button.Height;
        button.BeginAnimation(Button.HeightProperty, null);
        button.Height = currentHeight + 10;
    }
    private void _animateButton_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation animation = new DoubleAnimation
        {
            By = 10,
            Duration = new Duration(TimeSpan.FromSeconds(1))
        };
        button.BeginAnimation(Button.HeightProperty, animation);
    }
