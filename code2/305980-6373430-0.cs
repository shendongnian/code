    private Dictionary<string, IMetaData> metaData;
    public PersonAddress Address {
        get { return (PersonAddress)metaData["Address"]; }
        set { metaData["Address"] = value; }
    }
