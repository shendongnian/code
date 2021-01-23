    //Gather your position data
    var XY = new List<Point>();
    {
      { new Point(0, 0) },
      { new Point(10, 20) },
      { new Point(15, 5)},
      { new Point(0,0)},
      { new Point(10,20)}
    };
    //Gather your Z values ..
    var Z = new List<double>() { 0, 10, 20, 30, 40 };
    //Build the lookup
    var lookup = XY.Zip(Z, (xy, z) => new { Point = xy, Z = z }).ToLookup(k => k.Point, v => v.Z);
    //Process...
    //foreach unique XY (the Key of the lookup)
    //  Check to see if the XY is in a set of MatchingIndexes.  If not, continue.
    //  Add the unique point to the chart series.
    //  Get the Z values that correspond to the key (no need for ToList unless ApplyStatistics needs something more specialized than IEnumerable).
    //  Apply the Z values by calling ApplyStatistics
    //
    foreach (g in lookup.Select(g => g.Key))
    {
      var matched = MatchingIndexes.Select(i => i == g);
      if (!matched.Any()) continue;
      chart1.Series[0].Points.AddXY(g.X, g.Y);
      var singleZGroup = lookup[g];
      ApplyStatistics(singleZGroup);
    }
