    public ActionResult Index()
    {
        var result = (from r in db.rentails
                      join c in db.cars on r.carno equals c.carno
                      select new RentailViewModel
                      {
                          RentalId = r.RentalId,
                          carno = r.carno,
                          Available = c.Available,
                          // The rest of properties here
                      }).ToList();
        return View(result);
    }
