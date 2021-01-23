    <Canvas Name="myCanvas" MouseDown="MouseDownHandler" />
    public void MouseDownHandler(object sender, MouseButtonEventArgs e)
    {
        HitTestResult target = VisualTreeHelper.HitTest(myCanvas, e.GetPosition(myCanvas));
        while(!(target is Control) && (target != null))
        {
            target = VisualTreeHelper.GetParent(target);
        }
        // now if target is not null, it's the control that was clicked...
    }
