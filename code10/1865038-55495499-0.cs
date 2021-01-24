    private bool _isFading;
    
    public void fade()
    {
        // Is the fading already doing its thing?  If so, get out
        if( _isFading )
           return;
        // nope, not yet, first time in, set flag to prevent subsequent calls
        // against this same object
        _isFading = true;
    
        if objectname.material.color = (1f, 1f, 1f, 0f);
           StartCoroutine(OPTION1());
    
        if objectname.material.color = (1f, 1f, 1f, 1f);
           StartCoroutine(OPTION2());
    
        // reset now that the fading is complete
        _isFading = false;
    }
