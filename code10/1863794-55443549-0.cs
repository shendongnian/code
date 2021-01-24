    var categories = unitOfWork.Category
                               .GetAll()
                               .Select(x => new
                                             {
                                               Id = x.Id,
                                               Name = x.Name,
                                               CategoryName = x.CategoryId == null ? "" : x.Parent.Name
    
                                             }).ToList();
