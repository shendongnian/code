    [HttpPost]
    public ActionResult Create(EditGrantApplicationViewModel editGrantApplicationViewModel)
    {
       if (!ModelState.IsValid)
       {
          return View("Create", editGrantApplicationViewModel);
       }
    
       GrantApplication grantApplication = new GrantApplication();
       grantApplication. // other fields.
       grantApplication.Reason = editGrantApplicationViewModel.ReasonForEdit.SelectedValue;
       grantApplication. // other fields.
       _someService.EditApplication(grantApplication);
    
       return View("Index");
    }
