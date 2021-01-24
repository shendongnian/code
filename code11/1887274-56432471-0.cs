    public bool ResizeTop
    {
        get { return resizeTop; }
        set
        {
            resizeTop = value;
            ResizeOptionsChanged?.Invoke(this);
        }
    }
