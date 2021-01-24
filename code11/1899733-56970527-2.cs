    public ActionResult Arrears()
    {
        DateTime minDate = DateTime.UtcNow.AddMonths(-4);
        var subscribers = db.Subscriptions
          .Where(s => s.SubscriptionDate >= minDate)
		  .Select(s => s.UserName);
        return View(
			db.Members.Select(m => m.UserName)
			.Where(u => subscribers.All(s => s != u))
			.ToList());
	}
	
