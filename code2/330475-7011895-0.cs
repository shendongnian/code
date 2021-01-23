    <Canvas Name="myCanvas" MouseDown="MouseDownHandler" />
    public void MouseDownHandler(object sender, ? e)
    {
        var target = VisualTreeHelper.HitTest(e.GetPosition(myCanvas));
        while((!target is Control) && (target != null))
        {
            target = VisualTreeHelper.GetParent(target);
        }
    }
    // out of my head, didn't test this!
