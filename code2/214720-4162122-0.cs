    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ProcessForm(FormCollection formValues)
    {
        ...
        // Perform validation, sending error messages to ModelState
        ...
        if (!Model.IsValid)
        {
            AddressViewModel viewModel = new AddressViewModel
            {
                StreetAddress = formValues["StreetAddress"],
                City = formValues["City"],
                ...
            };
            
            return View(viewModel);
        }
    }
