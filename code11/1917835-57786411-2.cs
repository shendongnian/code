    [HttpGet]
        public IActionResult userProfile(UserProfileRetrieveModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.First(x => x.Email == model.UserEmail);
                //etc
            }
            else
            {
    
                return BadRequest(ModelState);
    
            }
        }
