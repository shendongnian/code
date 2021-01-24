    private bool _shouldHighlight = false;
    public bool ShouldHighlight
    {
        get => _shouldHighlight;
        set
        {
            _shouldHighlight = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShouldHighlight)));
        }
    }
