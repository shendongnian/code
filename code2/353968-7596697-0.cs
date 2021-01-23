    var dict = new Dictionary<string, object> { { "Property", "foo" } };
    var eo = new ExpandoObject();
    var eoColl = (ICollection<KeyValuePair<string, object>>)eo;
    
    foreach (var kvp in dict)
    {
    	eoColl.Add(kvp);
    }
    
    dynamic eoDynamic = eo;
    
    string value = eoDynamic.Property;
