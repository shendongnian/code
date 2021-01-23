		public static IEnumerable<int> ReadIntsFrom(string path)
		{
			using (var reader = File.OpenText(path))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
					yield return int.Parse(line);
			}
		}
