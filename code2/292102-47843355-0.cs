    var insertedRoute =routeRep.Insert(route);
    .....
    insertedRoute.LocationInRoute = new List<LocationInRoute>();
    for(....){
        var lInRoute = new LocationInRoute(){
        ....
        Route=insertedRoute;
    }
    insertedRoute.LocationInRoute.Add(lInRoute );
    }
