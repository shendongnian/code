    public ActionResult Edit(int id)
    {
        Contract contract = contractRepository.GetContract(id);
        var db = new ManagementDataContext();
        IEnumerable<SelectListItem> items = db.Sows
            .Select(s => new SelectListItem()
            {
                Value = s.ID.ToString(),
                Text = s.Title
            });
        ViewData["SowItems"] = items;
        return View(contract);
    }
    
