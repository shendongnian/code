		public static Dispatcher LoadFromFile()
		{
			Dispatcher loadedDataBase;
			try
			{
				using (var stream = new FileStream(FileName, FileMode.Open))
				{
					var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Dispatcher));
					loadedDataBase = serializer.ReadObject(stream) as Dispatcher;
				}
			}
			catch (Exception)
			{
				loadedDataBase = new Dispatcher();
			}
			return loadedDataBase;
		}
		public void SaveToFile()
		{
			using (var stream = new FileStream(FileName, FileMode.Create))
			{
				var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(this.GetType());
				serializer.WriteObject(stream, this);
			}
		}
