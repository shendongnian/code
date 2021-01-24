            try
            {
                if (ModelState.IsValid)
                {
                    bool result = *DatabaseStuff*
                    if(result == true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
       
 
        
