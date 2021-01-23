		private static void BinaryFormatterDemo()
		{
			// serialise 
			Exception ex = new Exception("Some message",
				new Exception("Another message"));
			Console.WriteLine(ex);
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream("ex.bin", FileMode.Create);
			bf.Serialize(fs, ex);
			fs.Close();
			// deserialise
			fs = new FileStream("ex.bin", FileMode.Open);
			Exception loadedEx = (Exception) bf.Deserialize(fs);
			Console.WriteLine(loadedEx);
			fs.Close();
		}
