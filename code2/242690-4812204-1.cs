    List<SelectListItem> items = new List<SelectListItem>(); 
                items.Add(new SelectListItem { Text = "Swimming", Value = "1" }); 
                items.Add(new SelectListItem { Text = "Cycling", Value = "2", Selected = true }); 
                items.Add(new SelectListItem { Text = "Running", Value = "3" });         
     
    // the line below uses LINQ to filter out the item with text of "Swimming"            
    var filteredList = from x in items
                        where x.Text != "Swimming"
                        select x;
    ViewData["Testing"] = new SelectList(filteredList, "Value", "Text");
    
