    IEnumerable<Building> buildings = buildingApiDTO.Where(numberOfRooms => (searchModel.NumberOfRooms == null || numberOfRooms.Appartments.Any(roomsCount => searchModel.NumberOfRooms.Contains(roomsCount.RoomsCount.ToString())))
        || (
            searchModel.IsStudio && 
            numberOfRooms.Appartments.Any(isStudio => isStudio.IsStudio) &&
            !searchModel.IsNoPlanning && 
            !searchModel.IsMultiRoom
            )
        || (
            searchModel.IsNoPlanning && 
            numberOfRooms.Appartments.Any(isNoPlanning => isNoPlanning.IsFreePlaning) && 
            !searchModel.IsStudio && 
            !searchModel.IsMultiRoom
            )
        || (
            searchModel.IsMultiRoom && 
            numberOfRooms.Appartments.Any(multiRoom => multiRoom.RoomsCount >= 4) && 
            !searchModel.IsStudio && 
            !searchModel.IsNoPlanning
            )
        )
