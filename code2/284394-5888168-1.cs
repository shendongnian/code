    public JsonResult GetCitiesByProvince(int ProvinceID)
    {
        var result = _someRepository.GetCities(ProvinceID).Select(
                c => new { CityID = c.CityID, City = c.City }); 
        JsonResult jsonResult = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        return jsonResult;
    }
