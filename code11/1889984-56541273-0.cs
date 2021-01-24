            [HttpPost]
            public ActionResult AddOrEdit(InputCP inputCP)
            {
    		
    		    ViewBag.UserID_TO = new SelectList(db.Users, "ID", "Name");
                ViewBag.UserID_CC = new SelectList(db.Users, "ID", "Name");
                ViewBag.UserID_Sales = new SelectList(db.Users, "ID", "Name");
    			
                try
                {
                    inputCP.Created = DateTime.Now;
                    inputCP.LastModified = DateTime.Now;
                    db.InputCPs.Add(inputCP);
                    db.SaveChanges();
    
                    ViewBag.Message = "Success";
                    return View();
    
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                    ViewBag.ErrorMessage = "An error occured, please check your data input and try again";
                }
                return View("Error");
    
            }
