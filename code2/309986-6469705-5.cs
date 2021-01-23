            // Post action
            [HttpPost]
            public ActionResult register (UserViewModel uvm)
            {
                // This validates the UserViewModel
                if (ModelState.IsValid)
                {
    
                    try
                    {
                        // You should delegate this task to a service but to keep it simple we do it here
                        User u = new User() { Email = uvm.Email, Created = DateTime.Now };
                        RedirectToAction("Index"); // On success you go to other page right?
                    }
                    catch (Exception x)
                    {
                        ModelState.AddModelError("RegistrationError", x); // Replace x with your error message
                    }
                    
                }       
    
                // Return your UserViewModel to the view if something happened               
                return View(uvm);
            }
