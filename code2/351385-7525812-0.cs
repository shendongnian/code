	var xs = new [] { 1, 3, 5, 6, 23, };
	var yss = new []
	{
		new [] { 3, },
		new [] { 6, 1, },
		new [] { 1, 3, 5, 23, 6, 14, 67, },
		new [] { 2, 3, },
	};
	var q1 =
		from ys in yss
		select ys.Intersect(xs);
	
	var q1b = yss.Select(ys => ys.Intersect(xs));
	
	var q2 =
		from ys in yss
		where ys.Intersect(xs).Any()
		select ys;
	
	var q2b = yss.Where(ys => ys.Intersect(xs).Any());
	
	var q3 =
		from x in xs
		where (
			from ys in yss
			from y in ys
			select y).Contains(x)
		select x;
	
	var q3b = xs.Where(x => yss.SelectMany(y => y).Contains(x));
	
	var q4 = xs.Intersect(yss.SelectMany(y => y));
