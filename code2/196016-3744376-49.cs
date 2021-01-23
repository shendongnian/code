    [HttpGet]
    public ActionResult GetCities(string country)
    {
        Check.Require(!string.IsNullOrEmpty(country), "State is missing");
    
        var query  = // get the cities for the selected country.
    		
        // Convert the results to a list of JsonSelectObjects to 
        // be used easily later in the loadSelect Javascript method.		 
    	List<JsonSelectObject> citiesList = new List<JsonSelectObject>();
            foreach (var item in query)
            {
                citiesList.Add(new JsonSelectObject { value = item.ID.ToString(),
                                                      caption = item.CityName });
            }		 
    
        return Json(citiesList, JsonRequestBehavior.AllowGet);
    }
