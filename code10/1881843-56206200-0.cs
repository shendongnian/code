    var annotatedAttributes = 
			typeof(Constants).GetProperties(BindingFlags.Static)
				.Where(x => x.GetCustomAttribute<InCludeEventLog>() != null)
				.ToList();
    // Since you are getting the value of static properties,
    // you can pass null to GetValue.
    // If you need the value of non-static properties, you need a class instance here.
    var keyValues = annotatedAttributes.ToDictionary(x => x.Name, x => x.GetValue(null));
