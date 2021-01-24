        [HttpGet]
        
        public IActionResult userProfile(string userEmail)
        {
             if ( !string.IsNullOrEmpty (userEmail) ) ..... etc etc
             {
                var user = _userManager.Users.First(x => x.Email == userEmail);
                return Ok(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });   
            }
        }
