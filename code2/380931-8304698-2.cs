    [HttpPost]
    public ActionResult RenderDatePartial(Date fromDate, Date toDate)
    {
        var dates = new List<Date> { fromDate, toDate };
        // Save IList returned from query
        var jsonObj = Model.query(dates);
    
        return PartialView("_DatePartial", jsonObj);
    }
