    var jsonResolver = new IgnorableSerializerContractResolver();
    // ignore single property
    jsonResolver.Ignore(typeof(Company), "WebSites");
	// ignore single datatype
    jsonResolver.Ignore(typeof(System.Data.Objects.DataClasses.EntityObject));
    var jsonSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = jsonResolver };
