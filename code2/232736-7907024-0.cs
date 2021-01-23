	var array = new byte[] { 5, 8, 9, 20, 70, 44, 2, 4 };
	array.Dump();
	var segment = new ArraySegment<byte>(array, 2, 3);
	segment.Dump(); // output: 9, 20, 70
	segment.Reverse().Dump(); // output 70, 20, 9
	segment.Any(s => s == 99).Dump(); // output false
	segment.First().Dump(); // output 9
	array.Dump(); // no change
