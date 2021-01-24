    [HttpPost]
           public JsonResult Add(string countryId)
            {
                int Id;
                Id = Convert.ToInt32(countryId);
        
                var states = from a in db.States where a.CountryId == Id select a;
                return Json(states, JsonRequestBehavior.AllowGet);
        
            }
