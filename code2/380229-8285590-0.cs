        [HttpPost]
        public ActionResult Create(PJCountry PJCountry)
        {
            if (ModelState.IsValid) 
            {   
                // adds current user's key
                PJcountry.YourUserKey = Membership.GetUser().ProviderUserKey.ToString();
                db.PJCountries.Add(PJcountry); 
                db.SaveChanges(); 
                return RedirectToAction("Index"); 
            } 
            return View(PJCountry);
        }
