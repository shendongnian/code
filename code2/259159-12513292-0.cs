     ModelState.Where(m => m.Key == "Avatar").FirstOrDefault().Value.Errors.Clear(); // At  this point ModeState will have an error for that Key, by applying Clear it remove the error so modelstate becomes valid again
    if (!ModelState.IsValid)
            {
                return View("User", model);
            }
            else
            {
                
                try 
                {
                   // do something
                }
                catch
                {
                   TempData["errorMessage"] = "something went wrong";
                }
            }  
