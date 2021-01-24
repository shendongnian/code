    var query = buildRepost.Get(buildId).AsQueryable();
    if (searchModel.NumberOfRooms != null)
    {
        query = query.Where(condStates  => searchModel.NumberOfRooms.Contains(condStates.RoomsCount.ToString());
    }
    if (searchModel.IsStudio)
    {
        query = query.Where(condStates  => condStates.IsStudio); 
    }
    if (searchModel.IsNoPlaning)
    {
        query = query.Where(condStates  => condStates.IsFreePlaning)
    }
    if (searchModel.IsMultiRoom)
    {
        query = query.Where(condStates  => condStates.RoomsCount >= 4)
    }
    var results = query.ToList()
