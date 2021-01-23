        private static IEnumerable<string> ReadLines(string fspec)
        {
            using (var reader = new StreamReader(new FileStream(fspec, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
            }
        }
		var dict = ReadLines("input.txt")
			.Select(s =>
						{
							var split = s.Split("|".ToArray(), 2);
							return new {Id = Int32.Parse(split[0]), Text = split[1]};
						})
			.ToDictionary(kv => kv.Id, kv => kv.Text);
