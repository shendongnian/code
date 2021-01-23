    public float inverseMass
    {
        get;
        set
        {
            if (inverseMass != value)
            {
                inverseMass = value;
                onMassChanged();
            }
        }
    }  
