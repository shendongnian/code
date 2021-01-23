	void Main()
	{
		var partitioner = new SimplePartitioner(GetEnumerator());
		
		GetEnumerator().Count().Dump();
		
		partitioner.GetPartitions(10).Select(enumerator =>
		{
			int count = 0;
			while (enumerator.MoveNext())
			{
				count++;
			}
			return count;
		}).Sum().Dump();
		
		var theCount = 0;
		partitioner.AsParallel().ForAll(e => Interlocked.Increment(ref theCount));
		theCount.Dump();
		
		partitioner.AsParallel().Count().Dump();
	}
	
	// Define other methods and classes here
	public IEnumerable<string> GetEnumerator()
	{
		for (var i = 1; i <= 100; i++)
			yield return i.ToString();
	}
	
	public class SimplePartitioner : Partitioner<string>
	{
		private IEnumerable<string> input;
		public SimplePartitioner(IEnumerable<string> input)
		{
			this.input = input;
		}
		
		public override IList<IEnumerator<string>> GetPartitions(int numPartitions)
		{
			var list = new List<string>[numPartitions];
			for (var i = 0; i < numPartitions; i++)
				list[i] = new List<string>();
			var index = 0;
			foreach (var s in input)
				list[(index = (index + 1) % numPartitions)].Add(s);
			
			IList<IEnumerator<string>> result = new List<IEnumerator<string>>();
			foreach (var l in list)
				result.Add(l.GetEnumerator());
			return result;
		}
	}
