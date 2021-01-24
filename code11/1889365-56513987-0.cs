    var newCarItemIds = carItems.Select(x => x.Id);
    var alreadyExistentCarItemIds = Entities.CarItems.Where(x => newCarItemIds.Contains(x.Id)).Select(x=>x.Id);
    
    foreach(var item in carItems)
    {
        if(!alreadyExistentCarItemIds.Contains(x))
        {
            carsCol.Add(item);
        }
    }
