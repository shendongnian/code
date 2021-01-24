    var parents = _context.Children
        .Include( c => c.Parent )
        .GroupBy( c => c.Parent )
        .ToArray()
        .Select( g => 
            {
                // assign children to g.Key (the parent object)
                g.Key.Children = g.ToArray(); // I don't know type of `Children` property
                // select parent
                return g.Key;
            } );
