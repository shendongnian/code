    using (DBModels db = new DBModels())
    {
        var clients = Enumerable.Empty<Client>();
        if (!String.IsNullOrEmpty(form.SearchString))
        {
            clients = db.Clients.Where(s => s.Full_Name.Contains(form.SearchString) || s.Class.Contains(form.SearchString)
            || s.Membership_Type.Contains(form.SearchString) || s.Membership_Type.Contains(form.SearchString) ||
            s.Notes.Contains(form.SearchString) || s.ClientID.Equals(form.SearchString));
        }
		
		if (form.IsChecked != null)
		{
			clients = clients.Where(t => t.Paid == form.IsChecked);
		}
			  
        return View(clients.ToList());
    }
