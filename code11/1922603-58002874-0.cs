        [HttpGet]
            public ActionResult AddNewHallRecord(ClsCityList city)
            { 
                /*
                How to get City list, State list, Country list for use 
                from three different tables, but use foreign keys 
                with this HallProfile table  
                */
    List<CiTyModel> city= (from x in fromintrface.GetAllList() select x).ToList().FirstOrDefault(n=>n.cityID == city.Id);
    
    SelectList cityList = new SelectList(cate, "Id", "CityName");
    
    ViewBag.CityList = cateList;
                return View();
            }
