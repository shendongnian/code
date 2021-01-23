	public static class ByteListExtensions
	{
		public static IEnumerable<int> AllIndexesOf(this IList<byte> source, int match, bool isLittleEndian = true)
		{
			if (source.Count < 4)
			{
				return Enumerable.Empty<int>();
			}
			var b0 = (byte)(match & (isLittleEndian ? 0xff000000 : 0x000000ff));
			var b1 = (byte)(match & (isLittleEndian ? 0x00ff0000 : 0x0000ff00));
			var b2 = (byte)(match & (isLittleEndian ? 0x0000ff00 : 0x00ff0000));
			var b3 = (byte)(match & (isLittleEndian ? 0x000000ff : 0xff000000));
			var indexes = Enumerable.Range(0, source.Count / 4)
				.AsParallel()
				.Select(x => x * 4)
				.Where(x => source[x] == b0)
				.Where(x => source[x + 1] == b1)
				.Where(x => source[x + 2] == b2)
				.Where(x => source[x + 3] == b3);
			return indexes;
		}
	}
