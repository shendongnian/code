    private Lazy<IEnumerable<CObject>> cObjects = new Lazy<IEnumerable<CObject>>(LoadCObjects);
    public IEnumerable<CObject> CObjects
    {
        get { return this.cObjects.Value; }
    }
