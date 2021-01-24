	var handlers = typeof(Program).Assembly
         // Get all types in the assembly
		.GetExportedTypes()
         // that are classes and implement IAppAction
		.Where(x => x.IsClass && x.GetInterface("IAppAction") != null)
		.Select(x => new 
		{
            // assuming they are always decorated with [AppActionName]
			Action = x.GetCustomAttribute<AppActionNameAttribute>().Action,
            // get a new instance, assuming parameterless constructor
			Handler = (IAppAction)Activator.CreateInstance(x)
		})
        // and convert it to a Dictionary that you can easily use
        .ToDictionary(x => x.Action, x => x.Handler);
