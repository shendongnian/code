    using (DBModels db = new DBModels())
    {
		var predicate = PredicateBuilder.New<Client>(true);
        if (!String.IsNullOrEmpty(form.SearchString))
        {
            predicate.And(s => s.Full_Name.Contains(form.SearchString) || s.Class.Contains(form.SearchString)
            || s.Membership_Type.Contains(form.SearchString) || s.Membership_Type.Contains(form.SearchString) ||
            s.Notes.Contains(form.SearchString) || s.ClientID.Equals(form.SearchString));
        }
		
		if (form.IsChecked != null)
		{
			predicate.And(t => t.Paid == form.IsChecked);
		}
			  
        return View(db.Clients.Where(predicate).ToList());
    }
