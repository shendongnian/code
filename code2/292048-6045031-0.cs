    public class LocationSequenceEqual : IEqualityComparer<Location>
        {
            public bool Equals(Location x, Location y)
            {
                return x.Id == y.Id;
            }
    
            public int GetHashCode(Location obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    
        public bool IsRouteExists(IList<LocationInRoute> locationsInRoute)
        {
            Route route = null;
            if (locationsInRoute.Count > 0)
            {
                var query = GetRoutesQuery().
                    Where(x => x.Locations.Count() == locationsInRoute.Count);
    
                query = query.Where(x => x.Locations.OrderBy(l => l.Order).
                        Select(l => l.Location).SequenceEqual(locations, new LocationSequenceEqual()));
                route = query.FirstOrDefault();
            }
            return route!=null;
        }
