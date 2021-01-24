    public object Clone()
    {
        Route route = new Route
        {
            //Cities = Cities
              Cities = this.Cities.ToList();
        };
        return route;
    }
