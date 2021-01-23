    // in Parent
    public void AddChild(Child c)
    {
        // need to check if Parent hasn't yet been set to this
        if (c.Parent != this) c.Parent = this;
        ...
    }
    public void RemoveChild(Child c)
    {
        // need to check if Parent is still set to this
        if (c.Parent == this) c.Parent = null;
        ...
    }
    public bool Contains(Child c)
    {
        // assuming ISet implements this function
        return Children.Contains(c);
    }
    
    // in Child
    public Parent Parent
    {
        ...
        set
        {
            Parent old = _Parent;
            _Parent = value;
            if ((old != null) &&
                (old.Contains(this)))
            {
                old.RemoveChild(this);
            }
            if ((_Parent != null) &&
                (!_Parent.Contains(this)))
            {
                _Parent.AddChild(this);
            }
        }
    }
