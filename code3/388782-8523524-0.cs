    [Serializable()]
		public struct Position
		{
			int timestamp;
			float x;
			float y;
		}
		
		static void Main(string[] args)
		{
			var positions = new Position[1000 * 1000];
			GetBytes(positions);
		}
		private static byte[] GetBytes(object obj)
		{
			using (var memoryStream = new System.IO.MemoryStream())
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, obj);
				return memoryStream.ToArray();
			}
		}
