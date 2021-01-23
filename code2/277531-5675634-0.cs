    private static IEnumerable<IEnumerable<object>> GetAllCombinations(IEnumerable<IEnumerable<object>> a)
		{
			if (!a.Skip(1).Any())
			{
				return a.First().Select(x => new[] { x });
			}
			var tail = GetAllCombinations(a.Skip(1)).ToArray();
			return a.First().SelectMany(f => tail.Select(x => new[] { f }.Concat(x)));
		}
