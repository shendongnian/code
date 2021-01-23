    [Personalizable(PersonalizationScope.User),
    WebBrowsable,
    WebDisplayName("Web part Title"),
    WebDescription("Description of property.")]
    public string WebPartTitle
    {
      get { return this.Title; }
      set { this.Title = value; }
    }
