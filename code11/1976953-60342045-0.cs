    public ActionResult Settings() {
    	smartpondEntities entities = new smartpondEntities();
        var alertList = entities.Alerts.ToList();
    	
    	List<AlertsViewModel> alertViewModel = alertList.Select(s=> new AlertsViewModel()
    																{
    																	Deviceid = //....
    																}).ToList();
    	return View(alertViewModel);
    }
