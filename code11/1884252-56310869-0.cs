	bool Zipper(IEnumerable<IEnumerable<string>> sources, int take)
	{
		IEnumerable<string> ZipperImpl(IEnumerable<IEnumerable<string>> ss)
			=> (!ss.Skip(1).Any())
				? ss.First().Take(take)
				: ss.First().Take(take).Zip(
					ZipperImpl(ss.Skip(1)),
					(x, y) => (x == null || y == null || x != y) ? null : x);
		
		var matching_lines = ZipperImpl(sources).TakeWhile(x => x != null).ToArray();
		return matching_lines.Length == take;
	}
