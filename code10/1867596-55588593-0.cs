		var data = content.Replace("}","").Replace("\r\n","\n").Split('{')
			.Select
			( 
				block => block.Split('\n')
				.Where
				( 
					line => !string.IsNullOrWhiteSpace(line)
				)
				.Select
				( 
					line => line.Split(new char[] {':'}, 2)
				)
				.ToDictionary
				( 
					fields => fields[0].Trim(), 
					fields => fields[1].Trim()
				)
			)
			.ToList();
		foreach (var list in data)
		{
			foreach (var entry in list)
			{
				Console.WriteLine("{0}={1}", entry.Key, entry.Value);
			}
		}
