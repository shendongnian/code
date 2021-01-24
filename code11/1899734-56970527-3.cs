	public ActionResult Arrears()
    {
        DateTime iterationDate = DateTime.UtcNow;
		var subscribers = 
			db.Subscriptions.Where(
				s => s.SubMonth == iterationDate.Month 
					&& s.SubYear == iterationDate.Year);
		
        for(int i=0; i<3; i++)
        {
			iterationDate = iterationDate.AddMonth(-1);
			subscribers = subscribers.Union(
				db.Subscriptions.Where(
				s => s.SubMonth == iterationDate.Month 
					&& s.SubYear == iterationDate.Year)
			);
        }
		
		var subscriberNames = subscribers.Select(s => s.UserName).Distinct();
		
		return View(
			db.Members.Select(m => m.UserName)
			.Where(u => subscriberNames.All(s => s != u))
			.ToList());
    }
	
