    [Obsolete("Shown event is deprecated.")]
    public new event EventHandler Shown
    {
        add { base.Shown += value; }
        remove { base.Shown -= value; }
    }
