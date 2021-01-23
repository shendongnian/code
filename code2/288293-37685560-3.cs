    #if DEBUG
			foreach(var attrTempl in attributeTemplates)
			{
				var templParams = attrTempl.Method.GetParameters();
				if (templParams.Length != 2)
					throw new Exception("Can't have " + templParams.Length + " type args in AttributeTemplate Delegate, must be Func<out Attribute, string>");
				var type1 = templParams[0].GetType();
				var type2 = templParams[1].GetType();
				if (!type1.IsSubclassOf(typeof(System.Attribute)))
					throw new Exception("Input parameter type " + type1.Name + " must inherit from System.Attribute");
				if (type2 != typeof(string))
					throw new Exception("Output parameter type " + type2.Name + " must be string");
			}
    #endif
