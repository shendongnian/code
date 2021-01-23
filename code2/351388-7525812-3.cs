	var q1 =
		from z in yss.Zip(
			xs.Aggregate(
				yss.AsEnumerable(),
				(_yss, x) => (
					from ys in _yss
					select ys.Except(new [] { x }).ToArray())),
			(ys, _ys) => new { ys, _ys })
		where !z._ys.Any()
		select z.ys;
		
	var q1b =
		yss.Zip(
			xs.Aggregate(
				yss.AsEnumerable(),
				(_yss, x) => _yss
					.Select(ys =>
						ys.Except(new [] { x }).ToArray())),
			(ys, _ys) => new { ys, _ys })
		.Where(z => !z._ys.Any())
		.Select(z => z.ys);
