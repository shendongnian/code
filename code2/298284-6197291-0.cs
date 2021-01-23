    using System.Linq;
    // ...
		var stationOneParts = new [] { "20-packing",
			"5269-stempad",
			"5112-freeze plug",
			"2644-o'ring",
			"5347-stem",
			"4350-top packing",
			"5084-3n1 body",
			"4472-packing washer",
			"3744-vr valve o'ring",
			"2061-packing spring",
			"2037-packing nut",
			"2015-latch ring",
			"stem assembly" };
		Random rand = new Random();
		stationOneParts = stationOneParts
			.Distinct()
			.Select(i => new { i, key=rand.Next() })
			.OrderBy(p => p.key)
			.Select(p => p.i)
			.ToArray();
