    private UserControl LoadControl(string userControlPath, params object[] constructorParameters)
		{
			var constParamTypes = new List<Type>();
			foreach (var constParam in constructorParameters)
			{
				constParamTypes.Add(constParam.GetType());
			}
			var ctl = Page.LoadControl(userControlPath) as UserControl;
			// Find the relevant constructor
			if (ctl != null)
			{
				var constructor = ctl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());
				// And then call the relevant constructor
				if (constructor == null)
				{
					throw new MemberAccessException("The requested constructor was not found on : " + ctl.GetType().BaseType);
				}
				
				// constructor.Invoke(ctl, constructorParameters);
				object[] cp = constructorParameters;
				constructor.Invoke(ctl, cp);
			}
			// Finally return the fully initialized UC
			return ctl;
		} 
