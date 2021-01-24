	public static class JsonExtensions
	{
		public static void CopyToBson(string inputPath, string outputPath, FileMode fileMode = FileMode.CreateNew)
		{
			using ( var textReader = File.OpenText(inputPath) )
			using ( var jsonReader = new JsonTextReader( textReader ))
			using ( var oFileStream = new FileStream( outputPath, fileMode ) )
			using ( var dataWriter = new BsonDataWriter(oFileStream) )
			{
				dataWriter.WriteToken(jsonReader);
			}
		}
	}
