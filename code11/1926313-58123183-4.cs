    Session["searchFor"] = "Central";  //setting Session values for testing
    //Session["address"] = null; there is no need for this.
    var db = new Models.DB();
    List<Models.Station> allStations = db.Station.ToList();
    var searchForValue = (string) Session["searchFor"];
    foreach (Station station in allStations)
    {
        if (searchForValue.ToLower() == station.Name.ToLower())
        {
            Session["address"] = station.Address;
            break;
        }
    }
