	bool isValid = true;
	var invalidFields = new List<string>();
	foreach (var o in viewModels)
	{
		var properties = o.GetType()
			.GetProperties(BindingFlags.Public | BindingFlags.Instance);
		foreach(var prop in properties)
		{
			var attrs = prop.GetCustomAttributes(true);
			if (attrs != null)
			{
				var val = prop.GetValue(o);
				ValidationAttribute[] validatorAttrs = attrs
					.Where(a => a is ValidationAttribute)
					.Select(a => (ValidationAttribute)a).ToArray();
				foreach(var attr in validatorAttrs)
				{						
					bool thisFieldIsValid = attr.IsValid(val);
					if (!thisFieldIsValid)
						invalidFields.Add(prop.Name);
					isValid = isValid && thisFieldIsValid;
				}
			}
		}
	}
