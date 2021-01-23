    public ActionResult Create(string ds) {
                HandleException(() => {
                    InitializeServices(ds, "0000");
                    vm.Account = new Account {
                            PartitionKey = "0000",
                            RowKey = "0000",
                            Created = DateTime.Now,
                            CreatedBy = User.Identity.Name
                    };
                }); 
                return View("CreateEdit", vm);
            }
    
        private void HandleException(Action action) {
            try { 
                action(); 
            } 
            catch (ServiceException ex) { 
                ModelState.Merge(ex.Errors); 
            } 
            catch (Exception e) 
            { 
                Trace.Write(e); 
                ModelState.AddModelError("", "Database access error: " + e.Message); 
            } 
    } 
