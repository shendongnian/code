    Random r = new Random(Title.GetHashCode());
    Dictionary<object, int> map = new Dictionary<object, int>(_Games.Count);
    foreach( object game in _Games )
    {
        map.Add(game, r.nextInt());
    }
    _Games = _Games.OrderByDescending( g => map[g] );
