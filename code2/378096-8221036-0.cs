    private Image _favicon;
    private void WebBrowser1_DocumentCompleted(...) {
        _favicon = ...get the icon...;
        TabControl1.Invalidate();
    }
    private void TabControl1_OnDrawItem(...) {
        if (_favicon != null)
            e.Graphcs.DrawImage(_favicon, ...);
    }
