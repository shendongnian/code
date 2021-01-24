    Dictionary<int, string> dict = new Dictionary<int, string>();
    dict.Add( 0, "Welcome" );
    traces
        .AsEnumerable()
        .Select( t => new TraceLabelData() { Name = dict[0] } )
        .ToList();
