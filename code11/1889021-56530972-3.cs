	public ActionResult SaveDevice(DeviceUnderTestViewModel model)
	{
		using (var db = new dbContext())
		{
			DeviceUnderTest device = new DeviceUnderTest()
			{
				pkHardware = model.HardwareId,
				// continue with other items
			 };
			db.Entry<device>.State = EntiyState.Added;
			db.SaveChanges();
		}
        return View();
	}
