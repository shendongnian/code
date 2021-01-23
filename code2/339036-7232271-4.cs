    public ActionResult GetCountryCode(int countryId)
    {
        //logic to find country code goes here
        string countryCode = "1";
        return Content(countryCode);
    }
