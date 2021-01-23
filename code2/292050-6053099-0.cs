    public bool IsRouteExists(IList<LocationInRoute> locationsInRoute)
    {
        Route route = null;
        if (locationsInRoute.Count == 0)
            return;
        var possibleRoutes = GetRoutesQuery().
            Where(x => x.Locations.Count() == locationsInRoute.Count);
        var db = GetDataContext(); //get a ref to the DataContext or pass it in to this function
        for (var i = 0; i < locationsInRoute.Length; i++)
        {
            var lcoationInRoute = locationsInRoute[i];
            possibleRoutes = possibleRoutes.Where(x => x.Locations.Any(l => l.Id == locationInRoute.Id && l.Order == locationInRoute.Order));
        }
        route = possibleRoutes.FirstOrDefault();
        return route!=null;
    }
