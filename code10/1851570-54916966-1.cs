    private Point? _lastPoint;
    private void Thumb_MouseDown(object sender, MouseButtonEventArgs e)
    {
        _lastPoint = e.GetPosition(Tracker);
        Thumb.CaptureMouse();
    }
    private void Thumb_MouseMove(object sender, MouseEventArgs e)
    {
        if (_lastPoint != null)
        {
            var currentPoint = e.GetPosition(Tracker);
            var offset = currentPoint - _lastPoint.Value;
            _lastPoint = currentPoint;
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                offset *= 0.2;
            }
            SetThumbTranslation(offset.X);
        }
    }
    private void Thumb_MouseUp(object sender, MouseButtonEventArgs e)
    {
        _lastPoint = null;
        Thumb.ReleaseMouseCapture();
    }
    private void Thumb_LostMouseCapture(object sender, MouseEventArgs e)
    {
        _lastPoint = null;
    }
    private void SetThumbTranslation(double offsetX)
    {
        var x = ThumbTranslation.X + offsetX;
        x = Math.Max(x, 0);
        x = Math.Min(x, Tracker.ActualWidth);
        ThumbTranslation.X = x;
    }
