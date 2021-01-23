		public IEnumerable<MethodInfo> GetMvcActionMethods()
		{
			return
				Directory.GetFiles(Assembly.GetExecutingAssembly().Location)
					.Select(Assembly.LoadFile)
					.SelectMany(
						assembly =>
						assembly.GetTypes()
								.Where(t => typeof (Controller).IsAssignableFrom(t))
								.SelectMany(type => (from action in type.GetMethods(BindingFlags.Public | BindingFlags.Instance) 
													 where action.ReturnType == typeof(ActionResult) 
													 select action)
										    )
						);
		}
