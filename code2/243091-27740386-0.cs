    //Razor View
         @Html.DropDownList("StateID", (SelectList)ViewBag.stateList, "--Select--")
     
     //Code
        public ActionResult Create()
          {
             MyOtherData d = new MyOtherData();
             //Load the Dropdown here
             ViewBag.stateList = new SelectList(db.State, "StateID", "Name");
             return View(d);
          }
    
      [HttpPost]
    //Notice the second parameter StateID must match the 4th parameter in the ViewBag SelectList Below
    //The 4th parameter will act like the SelectedItem we were all familiar with in ASP.Net
        public ActionResult Create(ModelData data, String StateID)
        {
            if(ModelState.IsValid)
            {
              //...  
            }
           //Return SelectList to the dropdownlist here
            ViewBag.stateList = new SelectList(db.State, "StateID", "Name", StateID);
            
            return View(data);
        }
