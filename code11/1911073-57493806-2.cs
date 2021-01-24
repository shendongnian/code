    private void ParentOnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _isDraggingDot = false;
        CentreDot();
    }
    private void CentreDot()
    {
        dot.SetValue(Canvas.LeftProperty, (canvas.Width / 2.0) - (dot.Width / 2.0));
        dot.SetValue(Canvas.TopProperty, (canvas.Height / 2.0) - (dot.Height / 2.0));
    }
