    void Canvas_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent("MyFormat"))
        {
            var module = e.Data.GetData("MyFormat") as Module;
            Canvas CanvasView = sender as Canvas;
            Image image = new Image();
            image.Source = module.ModuleImage;
            image.SetValue(Canvas.LeftProperty, _enterPoint.X);
            image.SetValue(Canvas.TopProperty, _enterPoint.Y);
            CanvasView.Children.Add(image);
        }
    }
    private Point _enterPoint;
    private void Canvas_DragOver(object sender, DragEventArgs e)
    {
        _enterPoint = e.GetPosition(this.moduleCanvas);
        messenger.Send<Point>(_enterPoint, MessengerTopics.MousePoint);
    }
