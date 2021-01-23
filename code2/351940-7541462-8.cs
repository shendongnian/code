    // bad, consumer can do anything with the Graphics object
    public Graphics Graphics
    {
        get { return graphics; }
    }
    // good, consumer can only do specific stuff
    public void Draw(...)
    {
        graphics.Draw(...);
    }
