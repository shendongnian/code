    private static dynamic CustomerToCustomObject<TAttribute>(Customer customer) 
        where TAttribute : BaseAttribute // assuming the Name property is on a base class for all attributes
	{
		dynamic result = new ExpandoObject();
		var dictionary = (IDictionary<string, object>)result;
		
		var propertiesToInclude = typeof(Customer).GetProperties()
            .Where(property => property.GetCustomAttributes(typeof(TAttribute), false).Any());
		foreach (var property in propertiesToInclude)
		{
			var attribute = (BaseAttribute)(property.GetCustomAttributes(typeof(TAttribute), false).Single());
			dictionary.Add(attribute.Name, property.GetValue(customer));
		}
		return result;
	}
