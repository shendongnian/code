    var dateRetrieved = DateTime.Now;
    var items = _unitofWork.ItemRepo.All.Where(x => x.Id == Id)
       .Select(x => new ItemList
       {
           ItemId= item.Id,
           Name = item.Name,
           Color = item.Feature.Color,
           DateReteived = dateRetrieved
       }).ToList();
    return items;
