        [HttpGet]
            public ActionResult ViewUser(string id)
            {
                UserViewModel User = GenerateTestDataUsers().Find(x => x.UserID == id);     
    //In real life application you will be calling data service or entityframework
                    
                return View(User);
        
            }
