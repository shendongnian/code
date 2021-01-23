    if (ModelState.IsValid) {
 
        try {
            dinner.HostedBy = "SomeUser";
 
            dinnerRepository.Add(dinner);
            dinnerRepository.Save();
 
            return RedirectToAction("Details", new{id=dinner.DinnerID});
        }
        catch {
            ModelState.AddModelErrors(dinner.GetRuleViolations());
        }
    }
