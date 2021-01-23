    public ActionResult AddTableTo(Int64 id)
            {
                var tableService = id;
                var tableServiceName = db.VipServices.Single(x => x.VipServiceId == id);
                var venueId = tableServiceName.Event.Venue.VenueId;
                ViewData["TablerServiceNameFor"] = tableServiceName.Customer.FullName;
                ViewData["TableServiceFor"] = tableService;
    
                ViewBag.SeatingAreaId = new SelectList(db.SeatingAreas.Where(y => y.VenueId == venueId), "SeatingAreaId", "AreaName");
                
                return View();
            }
