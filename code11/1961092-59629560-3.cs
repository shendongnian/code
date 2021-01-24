    private Vector2 _point2;
    private TimeSpan _animationElapsedTime = TimeSpan.Zero;
    
    private void OnUpdate(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, 
          Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
    {
        _animationElapsedTime += args.Timing.ElapsedTime;
        var percentage = Math.Min(_animationElapsedTime.TotalSeconds / 5.0f, 1f);
        _point2 = Tween(_point1, _targetPoint, percentage);
    }
