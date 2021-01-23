    contexti.Load<tblAdmin>(query).Completed += (sender, args) =>
    {
        List<AdminInfo> list = new List<AdminInfo>();
        //for each entity returned, create a new AdminInfo and add it to the list
        foreach (var item in ((LoadOperation<Car>)sd).Entities)
        {
            list.Add(new AdminInfo(){ AdminId = item.AdminId, AFirtsName = item.FirstName /*other properties*/});
        }
    }
