    public Resource()
    {
        _Regions = new List<Region>();
        _Directs = new List<Direct>();
    }
    IList<Direct> _Directs;
    public virtual IList<Direct> Directs { get { return _Directs; } }
    
    IList<Region> _Regions;
    public virtual IList<Region> Regions { get { return _Regions; } }
