    public ActionResult AddTableToTable(Int16 sid, Int64 vid)
            {
                var tableService = vid;
                var tableServiceName = db.VipServices.Single(x => x.VipServiceId == vid);
                var seatingAreaId = sid;
                var seatingArea = db.SeatingAreas.Single(x => x.SeatingAreaId == sid);
    
                ViewData["TablerServiceNameFor"] = tableServiceName.Customer.FullName;
                ViewData["TableServiceFor"] = tableService;
                ViewData["SeatingAreaName"] = seatingArea.AreaName;
    
                ViewBag.TableId = new SelectList(db.Tables.Where(y => y.SeatingAreaId == seatingAreaId), "TableId", "TableName");
    
                return View();
            }
