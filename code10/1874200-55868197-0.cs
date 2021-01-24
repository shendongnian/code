    private HwndSource _source;
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        _source = PresentationSource.FromVisual(this) as HwndSource;
        _source.AddHook(WndProc);
    }
    protected override void OnClosed(EventArgs e)
    {
        _source.RemoveHook(WndProc);
        base.OnClosed(e);
    }
