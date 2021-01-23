    private float _inverseMass;
    
    public float inverseMass
    {
        get { return _inverseMass; }
        set
        {
            _inverseMass = value;
            onMassChanged();
        }
    }
