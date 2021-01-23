    public Texture target
    {
        get { return texture; }
        set { SetTarget(value); }
    }
    
    protected abstract SetTarget(Texture target);
