    PropertyInfo[] properties = this.GetType().GetProperties();
    foreach (PropertyInfo property in properties)
		{
			if (property.PropertyType.IsAssignableFrom(typeof(IEnumerable<IAnimal>)))
			{
				property.Dump();
			}							
		}
