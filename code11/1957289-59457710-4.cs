    [HttpGet]
    public IActionResult read()
    {
        //Database call to read dates and convert them to JSON object...
        List<SelectedDates> highlightDates = new List<SelectedDates>();
            highlightDates.Add(new SelectedDates { Date = new DateTime(2019, 12, 
        1), Title = "Birthday" });
        return Json(highlightDates);
    }
