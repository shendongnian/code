     You can use System.device.Location
    
    System.device.Location.GeoCoordinate gc = new System.device.Location.GeoCoordinate(){
    Latitude = yourLatitudePt1,
    Longitude = yourLongitudePt1
    };
    
    System.device.Location.GeoCoordinate gc2 = new System.device.Location.GeoCoordinate(){
    Latitude = yourLatitudePt2,
    Longitude = yourLongitudePt2
    };
    
    Double distance = gc2.getDistanceTo(gc); 
