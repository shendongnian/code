    public void Foo(Image image)
    {
        // This change won't be seen by the caller: it's changing the value
        // of the parameter.
        image = Image.FromStream(...);
    }
    public void Foo(ref Image image)
    {
        // This change *will* be seen by the caller: it's changing the value
        // of the parameter, but we're using pass by reference
        image = Image.FromStream(...);
    }
    public void Foo(Image image)
    {
        // This change *will* be seen by the caller: it's changing the data
        // within the object that the parameter value refers to.
        image.RotateFlip(...);
    }
