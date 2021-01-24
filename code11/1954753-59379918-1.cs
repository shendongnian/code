	var deserializationSettings = new JsonSerializerSettings
	{
		SerializationBinder = new DocumentBinder(),
		TypeNameHandling = TypeNameHandling.Objects, // Or Auto as appropriate
		Error = (sender, args) =>
		{
			if (args.CurrentObject == args.ErrorContext.OriginalObject
				&& args.ErrorContext.Error.GetBaseException() is JsonSerializationBinderException
				)
			{
				args.ErrorContext.Handled = true;
			}
		},
		// Other settings as required
	};
