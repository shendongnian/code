    private bool? property;
    public bool Property
    {
        set
        {
            property = value;
            someControl.Visible = value;
        }
        get
        {
            return property.GetValueOrDefault();
        }
    }
    public void ResetProperty() { property = null; }
    public bool ShouldSerializeProperty() { return property.HasValue; }
