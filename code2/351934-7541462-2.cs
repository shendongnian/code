    // bad, consumer can do anything with the Graphics object
    public property Graphics
    {
        get { return _graphics; }
    }
    // good, consumer can only do specific stuff
    public void Draw(...)
    {
        _graphics.Draw(...);
    }
