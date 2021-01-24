    var minusListVariable= _context.Card
                .Where(x => x.Login == userName && x.Year == numberYear &&
                       x.Month < numberMonth && x.selectboxlist=="2")
                .Select(b => string.IsNullOrEmpty(b.Minus) ? TimeSpan.Zero : TimeSpan.Parse(b.Minus))
                .ToList();
    var sumMinusListVariable = minusListVariable.Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
