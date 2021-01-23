	void Main()
	{
		string myString;
		
		using (var stream = new MemoryStream())
		{
			Print(stream);
		
			stream.Position = 0;
			using (var reader = new StreamReader(stream))
			{
				myString = reader.ReadToEnd();
			}
		}
	}
