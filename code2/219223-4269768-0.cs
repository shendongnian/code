    private string prop2; // this is the backing field
    public string Prop2
    {
        get
        {
            return prop2;
        }
        set
        {
            prop2 = EditString(value);
        }
    }
