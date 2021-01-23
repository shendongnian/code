    private IEnumerable<CObject> cObjects;
    public IEnumerable<CObject> CObjects
    {
        get
        {
            if (this.cObjects == null)
                lock (this.someLockObject)
                    if (this.cObjects == null)
                        this.cObjects = this.LoadCObjects();
            return this.cObjects;
        }
    }
