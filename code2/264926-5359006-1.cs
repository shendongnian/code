    var properties = new [] {
        new {Name = "Software", Setter = new Action<string>(value => this.Software = value)},
        new {Name = "Version", Setter = new Action<string>(value => this.Version= value)},
        new {Name = "ApiVersion", Setter = new Action<string>(value => this.ApiVersion = value)},
        // ...
        new {Name = "NewsPad", Setter = new Action<string>(value => this.NewsPad = bool.Parse(value))},
    }
    foreach (var property in properties)
    {
        Data.ReadToFollowing(property.Name);
        property.Setter(Data.ReadElementContentAsString());
    }
