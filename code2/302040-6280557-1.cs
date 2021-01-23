    public void SetSkin(ISkin newSkin)
    {
        // detach handlers from previous instance
        DetachHandlers();
        
        // swap the instance
        _skin = newSkin;
        
        // attach handlers to the new instance
        AttachHandlers();
    }
    void DetachHandlers()
    {
        if (_skin != null)
           _skin.Blink -= OnBlink;
    }
    
    void AttachHandlers()
    {
        if (_skin != null)
           _skin.Blink += OnBlink;
    }
    
