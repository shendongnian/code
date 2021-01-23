    public ActionResult Foo()
    {
        IEnumerable<TruckData> model = 
            from p in KowaDataContext.tblTrucks
            orderby p.Truck
            select new TruckData { Truck = p.Truck };
        return View(model);
    }
