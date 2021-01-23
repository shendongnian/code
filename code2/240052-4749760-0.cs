    private void Slider_ValueChanged(
        object sender,
        RoutedPropertyChangedEventArgs<double> e)
    {
        var slider = sender as Slider;
        var tick = slider.Ticks
            .Where(xx => Math.Abs(e.NewValue - xx) < slider.LargeChange);
        if (tick.Any())
        {
            var newValue = tick.First();
            if (e.NewValue != newValue)
            {
                DispatcherInvoke(() => slider.Value = newValue);
            }
        }
    }
