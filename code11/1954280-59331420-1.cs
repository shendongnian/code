    [HttpPost]
        public ActionResult Submit(SearchRolesViewModel searchRolesViewModel)
        {
            try
            {
                SearchRolesModel objUser = new SearchRolesModel();
                if (searchRolesViewModel.User_Id != string.Empty && searchRolesViewModel.NewUserHealthPlans != string.Empty && searchRolesViewModel.UserRole != string.Empty && searchRolesViewModel.NewUserPrimaryHealthPlan != string.Empty)
                {
                    //here we call the Exists method from an user repository to check for duplicate entries 
                    var isDuplicated = _userRepository.Exists(user => user.NTUSERID == objUser.NTUSERID && user.HPID == objUser.HPID);
        
                   if(isDuplicated) 
                   {
                       ViewBag.Message = "User exists already!";
                       Return Foo(); // return for the more appropriate page
                   }
                   else
                   {
                       objUser.SaveUser(searchRolesViewModel, System.Web.HttpContext.Current.Session["UserID"].ToString());
                       ModelState.Clear();
                       ViewBag.Message = "User added successfully";
                       return UserDetails();
                    }
                }
            }
            catch (Exception)
            {
                throw ;
            }
        }
