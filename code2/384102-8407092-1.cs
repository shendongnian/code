    [ProtoMember(16)]
    public SensorState RawData
    {
        get { return _rawData ?? (_rawData =  new SensorState(this, DateTime.Now, new Dictionary<DateTime, float>(), "", true, null)); }
        private set { _rawData = value; }
    }
