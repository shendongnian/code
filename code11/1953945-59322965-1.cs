    public JsonResult GetCars(int page, int limit)
    {
      //Your context get cars from DB with limit and page
      List<Cars> cars = _context.CarsSelect(limit, page); 
      var carsJSON = from c in cars 
      select new {
             CarID = c.CarID,
             Brand = c.Brand 
             Price = c.Price
      };      
      return Json ( new { carsJSON }, JsonRequestBehavior.AllowGet);;
    }
