	class Loader : MarshalByRefObject
	{
		public void Load(string file)
		{
			var assembly = Assembly.LoadFile(file);
			// Do stuff with the assembly.
		}
	}
