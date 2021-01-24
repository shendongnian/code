    private void UpdateButton(object sender, EventArgs e)
    {
        foreach (object obj in ButtonGrid.Children)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (obj != null && obj.HasColor)
                {
                    if (obj.State.ON)
                    {
                        obj.Color = obj.color_off;
                    }
                    else
                    {
                        obj.Color = new RadialGradientBrush(((SolidColorBrush)Brushes.White).Color, ((SolidColorBrush)obj.color_on).Color);
                    }
                }
            }, System.Windows.Threading.DispatcherPriority.Background);
        }
    }
The above code would be run without using a background worker. And user input should be handled between each `obj` in the loop.
