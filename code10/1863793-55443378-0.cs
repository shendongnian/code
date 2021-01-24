     [HttpGet]
    public JsonResult LoadCategory()
    {
         var categories = unitOfWork.Category
                                    .GetAll()
                                    .Select(x => new
                                                 {
                                                      Id = x.Id,
                                                      Name = x.Name,
                                                      CategoryName = x.Parent.Name
                                                 }).ToList();
        return Json(categories);
    }
