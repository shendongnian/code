	public ActionResult Index()
	{
		DeviceUnderTestViewModel vm = new DeviceUnderTestViewModel();
		vm.HardwareSelectList = db.Hardware.ToList().Select(d => new SelectListItem()
			{
				Text = d.nkHardware,
				Value = d.pkHardware.ToString()
			});
		
		// populate all the other dropdowns
		
		return View();
	}
	
