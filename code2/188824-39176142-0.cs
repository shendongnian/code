    [ConfigurationProperty("title", IsRequired = true, DefaultValue = "something")]
    [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;’\"|\\"
      , MinLength = 1
      , MaxLength = 256)]
    public string Title
    {
        get { return this["title"] as string; }
        set { this["title"] = value; }
    }
