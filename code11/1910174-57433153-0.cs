    [HttpPost]
    public ActionResult OnPostAddApplication(YourFormObject formParams){
         if (!ModelState.IsValid)
                {
                    return View(formParams);
                }
    }
