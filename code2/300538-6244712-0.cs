    RotateTransform rt = new RotateTransform();
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation da = new DoubleAnimation();
        da.Duration = new Duration(TimeSpan.FromSeconds(10));
        da.From = 0;
        da.To = 60;
        rt.CenterX = 35;
        rt.CenterY = 0;
        rectangle1.RenderTransform = rt;
        rt.BeginAnimation(RotateTransform.AngleProperty, da);
    }
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        var x = rt.Angle; // x will have the value of current angle
    }
