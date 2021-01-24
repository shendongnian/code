    private bool _deserializing;
    [OnDeserializing()]
    internal void OnDeserializing(StreamingContext context)
    {
        _deserializing = true;
    }
    public double X
    {
        get { return _x; }
        set
        {
            if (!_deserializing)
            {
                if (!CalcNewPositions(value, _y))
                {
                    throw new ArgumentOutOfRangeException(value + " Out of Bounds: ");
                }
            }
            _x = value;
            _lastGoodX = value;
        }
    }
    ...
