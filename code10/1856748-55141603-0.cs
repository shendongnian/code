    #region Holiday Pie Chart
    ViewBag.msg = db.HoursPerSites.Count().ToString();
    var queryHoursPerSites = from r in db.HoursPerSites
            select new { Count = r.SiteHours, Value = r.SiteHours };
    var resultsQueryHoursPerSites = queryHoursPerSites.ToList(); // or HoursPerSitesCollection
    var holidayPieChart = new object[resultsQueryHoursPerSites.Count];
    int counter = 0; // 
    foreach (var record in resultsQueryHoursPerSites)
    {
        holidayPieChart[counter] = new object[] { record.Value.ToString(), record.Count };
    counter++;
    }
    string deserialisedResults = JsonConvert.SerializeObject(holidayPieChart, Formatting.None);
    // no idea what dataj2 is here ...
    ViewBag.dataj2 = new HtmlString(deserialisedResults);
    #endregion
