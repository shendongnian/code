    public ActionResult Edit(Person person)
    {
        ModelState.Remove("Id"); // This will remove the key 
        
        if (ModelState.IsValid)
           {
               //Save Changes;
           }
        }
    }
