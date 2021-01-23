    // public fields are a no-no, use properties instead
    public IExample LoadedClass { get; private set; } 
.
.
.
    LoadedClass = (IExample)Activator.CreateInstance(Config.Version);
