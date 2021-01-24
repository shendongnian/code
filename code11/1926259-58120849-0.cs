csharp
	static void DetectOverlap(List<Range> l)
	{
		foreach(var r in l)
		{
			var overlap = l.Any(x => x.Id != r.Id 
				  && ((r.Start == x.Start && r.End == x.End) 
					  || (r.Start >= x.Start && r.Start < x.End)
					  || (r.End > x.Start && r.End <= x.End)));
			if(overlap)
			{
				Console.WriteLine("Overlap detected");
				throw new Exception("Overlapping range detected");
			}
		}
		Console.WriteLine("Clean ranges");
	}
