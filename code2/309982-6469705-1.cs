    //Post action
            [HttpPost]
            public ActionResult register (UserViewModel uvm)
            {
                //This validates the userviewmodel
                if (ModelState.IsValid)
                {
    
                    try
                    {
                        //you should delegate this task to a service but to keep it simple we do it here
                        User u = new User() { Email = uvm.Email, Created = DateTime.Now };
                        RedirectToAction("Index"); //on succes you go to other page right?
                    }
                    catch (Exception x)
                    {
    
                        ModelState.AddModelError("RegistrationError", x); // Replace x with your errormessage
                    }
                    
                }       
    
                //Return your userviewmodel to the view if something happend
                
                return View(uvm);
            }
