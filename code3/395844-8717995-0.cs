    public float inverseMass
    {
        get
        {
            return _inverseMass;
        }
        set
        {
            onMassChanged();
            _inverseMass = value;
        }
    }
    private float _inverseMass;
