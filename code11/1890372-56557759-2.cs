    public async Task<IActionResult> CountryList()
    {
          ViewBag.Country = new SelectList(_context.Country, "Id", "CountryName");
          return View();
    }
    [HttpGet]
    public JsonResult GetCityList(int CountryId)
    {
          var citylist= new SelectList(_context.City.Where(c => c.Country.Id == CountryId),"Id","CityName");
          return Json(citylist);
            
    }
