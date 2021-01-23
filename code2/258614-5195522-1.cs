    public CanDoThis loadedClass;
    public Init()
    {
        /* load the object, according to which version we need... */
        if (Config.Version == "refA")
        {
            loadedClass = new RefA();
        }
        // etc
    }
