    void Sample(INumerable<SimeFile> simeFiles, Func<NoteChart, bool> noteChartPredicate)
    {
      var xyz =
        from sf in fimFiles
        from nc in sf.NoteCharts
        group nc by new{Matched=noteChartPredicate(nc), SimFile=sf} into g
        select new{g.Key.SimFile, g.Key.Matched, NoteCharts = g.ToList()};
      ...
    }
    Sample(simFiles, nc => nc.BPM >= 130 && nc.BPM <= 150);
