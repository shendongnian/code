	double tickPerDay = (double)(24.0 * 60.0 * 60.0 * 10000000.0);
	List<MyType> DataList = new List<MyType>() {
		new MyType() { Filename = "File_1", Index = 1, Time = (DateTime.Parse("1/1/1900").AddDays(42038)).AddTicks((long)(tickPerDay * .6924500000))},
		new MyType() { Filename = "File_2", Index = 2, Time = (DateTime.Parse("1/1/1900").AddDays(42038)).AddTicks((long)(tickPerDay * .6435300000))},
		new MyType() { Filename = "File_3", Index = 3, Time = (DateTime.Parse("1/1/1900").AddDays(42038)).AddTicks((long)(tickPerDay * .7962800000))},
		new MyType() { Filename = "File_4", Index = 4, Time = (DateTime.Parse("1/1/1900").AddDays(42038)).AddTicks((long)(tickPerDay * .9340600000))},
		new MyType() { Filename = "File_5", Index = 2, Time = (DateTime.Parse("1/1/1900").AddDays(42038)).AddTicks((long)(tickPerDay * .9561300000))},
		new MyType() { Filename = "File_6", Index = 1, Time = (DateTime.Parse("1/1/1900").AddDays(42039)).AddTicks((long)(tickPerDay * .9561300000))},
		new MyType() { Filename = "File_7", Index = 4, Time = (DateTime.Parse("1/1/1900").AddDays(42039)).AddTicks((long)(tickPerDay * .5551700000))},
		new MyType() { Filename = "File_8", Index = 2, Time = (DateTime.Parse("1/1/1900").AddDays(42038)).AddTicks((long)(tickPerDay * .9652200000))},
		new MyType() { Filename = "File_9", Index = 1, Time = (DateTime.Parse("1/1/1900").AddDays(42039)).AddTicks((long)(tickPerDay * .0111500000))},
		new MyType() { Filename = "File_10", Index = 3, Time = (DateTime.Parse("1/1/1900").AddDays(42039)).AddTicks((long)(tickPerDay * .0990100000))}
		};
	int maxIndex = DataList.Max(x => x.Index);
	var results = DataList.GroupBy(x => x.Index)
		.Select(x => Enumerable.Range(1, maxIndex)
			.Select(y => x.Any(z => z.Index == y) ? x.Where(z => z.Index == y).FirstOrDefault() : new MyType() { Filename = "File_spacer", Index = y, Time = DateTime.Parse("1/1/1900")})
			.ToList())
		.ToList();  
