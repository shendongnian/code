		var pairs = new Dictionary<string, Type>()
		{
			{
				DATA_CONNECTION_ELEMENT, typeof(DataConnectionPropertyDataBinding)
			},
			{
				FORM_PARAMETER_ELEMENT, typeof(FormParameterDataBinding)
			}
		};
		
		foreach (var pair in pairs)
		{
			if (node[pair.Key] != null)
			{
				ConstructorInfo ctor = pair.Value.GetConstructor(new[] { typeof(object), typeof(object), typeof(object) });
        		return ctor.Invoke(new object[] { form, node[pair.Key], inputableEntity });
			}
		}
