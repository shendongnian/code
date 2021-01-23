	class NumsInPlace
	{
		public int Num { get; set; }
		public bool InPlace { get; set; }
	}
	int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
	
	List<NumsInPlace> numsInPlace = new List<int>();
	for (int index = 0; i < numbers.length; i++)
	{
		int num = numers[index];
		numsInPlace.Add(new NumsInPlace() { Num = num, InPlace = (index == num) });
	}
	Console.WriteLine("Number: In-place?");
	foreach (var n in numsInPlace)
	{
		Console.WriteLine("{0}: {1}", n.Num, n.InPlace);
	}
