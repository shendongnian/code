    var query = buildingApidDto.AsQueryable();
    
    // check if search has number of rooms
    if (searchModel.NumberOfRooms != null) 
    {
       query = query.Where(numberOfRooms.Appartments.Any(roomsCount => searchModel.NumberOfRooms.Contains(roomsCount.RoomsCount.ToString())))
    }
    //check if search is studio
    if (searchModel.IsStudio)
    {
        query = query.Where(numberOfRooms => numberOfRooms.Appartments.Any(isStudio => isStudio.IsStudio)))
    }
    //check if search is no planning
    if (searchModel.IsNoPlanning)
    {
        query = query.Where(numberOfRooms => numberOfRooms.Appartments.Any(isNoPlanning => isNoPlanning.IsFreePlaning)))
    }
    //check if search is multi room
    if (searchModel.IsMultiRoom)
    {
        query = query.Where(numberOfRooms => numberOfRooms.Appartments.Any(multiRoom => multiRoom.RoomsCount >= 4))))
    }
