    Calendar.PreviewMouseUp += (o, e) =>
    {
        if (!e.OriginalSource.Equals(Calendar))
        {
            Mouse.Capture(null);
        }
    };
