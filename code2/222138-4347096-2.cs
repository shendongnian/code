    public static IDisposable TrackDrag(this UIElement element, 
        Action<Rect> dragging, Action dragComplete)
    {
        var mouseDown = Observable.FromEvent(...);
        var mouseMove = Observable.FromEvent(...);
        var mouseUp = Observable.FromEvent(...);
        return (from start in mouseDown
                from currentPosition in mouseMove.TakeUntil(mouseUp)
                        .Do(_ => {}, () => dragComplete())
                select new Rect(Math.Min(start.X, currentPosition.X),
                                Math.Min(start.Y, currentPosition.Y),
                                Math.Abs(start.X - currentPosition.X),
                                Math.Abs(start.Y - currentPosition.Y));
                ).Subscribe(dragging);
    }
