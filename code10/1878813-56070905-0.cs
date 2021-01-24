	var original = new	{ Name = "Albert", Age = 99 };
	
	var constructor = original.GetType().GetConstructors().First();
	
	var parameters = constructor.GetParameters();
	
	var properties = original.GetType().GetProperties();
	
	var arguments =
	(
		from pa in parameters
		join pr in properties on pa.Name equals pr.Name
		select pr.GetValue(original)
	).ToArray();
	
	var clone = constructor.Invoke(arguments);
