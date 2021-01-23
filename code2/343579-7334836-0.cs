    Random r = new Random(Title.GetHashCode());
    Dictionary<Game, int> map = new Dictionary<Game, int>(_Games.Count);
    foreach( Game g in _Games )
    {
        map.Add(g, r.nextInt());
    }
    _Games = _Games.OrderByDescending( g => map[g] );
