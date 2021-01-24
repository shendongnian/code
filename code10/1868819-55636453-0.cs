    public Object TestProperty { get; set; } = "test";
    private void GetFromName()
    {
       var properties = this.GetType().GetProperties();
       var foundProperty = properties.ToList().Find(property => property.Name == /* nameof(x) string */);
       var test = foundProperty.GetValue(/* object containing the property */);
    }
