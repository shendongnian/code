    [HttpPost]
     public ActionResult ResetUserPW(string userName) {
    	string newExcept;
    	MembershipUser user = Membership.GetUser(userName);
    	if (user != null) {
    		try {
    			string newPassword = Membership.GeneratePassword(8, 2);
    			if (user.ChangePassword(user.GetPassword(), newPassword)) {
    				var mailMessage = new UserMailer();
    				return PartialView();
    			}
    			else {
    				ModelState.AddModelError("Password", "There was an error processing your request (the password reset has failed). Please try again.");
    			}
    		}
    		catch (Exception ex) {
    			ModelState.AddModelError("Password", String.Format("There was an error processing your request({0}). Please try again.", ex.Message));
    		}
    	}
    	else {
    		ModelState.AddModelError("Password", "There is no record of the specified user in the database.");
    	}
    	
    	if (!ModelState.IsValid)
    		return Json(GetModelStateStateErrors(ModelState));
    
    	return Json(null);
    }
    private IEnumerable<ModelStateError> GetModelStateStateErrors(ModelStateDictionary dictionary) {
        foreach (var key in dictionary.Keys) {
            var error = dictionary[key].Errors.FirstOrDefault();
            if (error != null)
                yield return new ModelStateError(key, error.ErrorMessage);
        }
    }
