    var properties = new [] {
        new {Name = "Software", Setter = (value => this.Software = value)},
        new {Name = "Version", Setter = (value => this.Version= value)},
        new {Name = "ApiVersion", Setter = (value => this.ApiVersion= value)},
        // ...
    }
    foreach (var property in properties)
    {
        Data.ReadToFollowing(property.Name);
        property.Setter(Data.ReadElementContentAsString());
    }
