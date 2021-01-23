		private static string Call(object callByAttribute, string name, object[] args)
		{
			PropertyInfo prop = callByAttribute.GetType().GetProperties()
				.Where(p => p.IsDefined(typeof(CodeNameAttribute), false))
                 .SingleOrDefault(p => ((CodeNameAttribute)(p.GetCustomAttributes(typeof(CodeNameAttribute), false)).First()).Name == name);
			if (prop != null)
				return (string)callByAttribute.GetType().InvokeMember(prop.Name, BindingFlags.GetProperty, null, callByAttribute, null);
			MethodInfo method = callByAttribute.GetType().GetMethods()
				.Where(p => p.IsDefined(typeof(CodeNameAttribute), false))
                 .SingleOrDefault(p => ((CodeNameAttribute)(p.GetCustomAttributes(typeof(CodeNameAttribute), false)).First()).Name == name);
			if (method != null)
				return (string)callByAttribute.GetType().InvokeMember(method.Name,  BindingFlags.InvokeMethod, null, callByAttribute, args);
			
			throw new Exception("method/getter not found");
		}
        private static string Call(object callByAttribute, string name)
    	{
    		return Call(callByAttribute, name, null);
    	}
