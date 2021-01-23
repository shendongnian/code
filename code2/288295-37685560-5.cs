    #if DEBUG
			foreach(var attrTempl in attributeTemplates)
			{
				var templParams = attrTempl.Method.GetParameters();
				if (templParams.Length != 1)
					throw new Exception("Can't have " + templParams.Length + " params in AttributeTemplate Delegate, must be Func<out Attribute, string>");
				var type1 = templParams[0].ParameterType;
				var type2 = attrTempl.Method.ReturnType;
				if (!type1.IsSubclassOf(typeof(System.Attribute)))
					throw new Exception("Input parameter type " + type1.Name + " must inherit from System.Attribute");
				if (type2 != typeof(string))
					throw new Exception("Output parameter type " + type2.Name + " must be string");
			}
    #endif
