    //setting Session values for testing
    Session["searchFor"] = "Central";
    //Session["address"] = null; there is no need for this.
    var db = new Models.DB();
    
    List<Models.Station> allStations = db.Station.ToList();
    var searchForValue = (string) Session["searchFor"];
    var station = allStations.FirstOrDefault(x => x.Name.ToLower() == searchForValue.ToLower());
    if (station != null)
    {
        Session["address"] = station.Address;
    }
