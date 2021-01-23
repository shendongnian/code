    List<SelectListItem> items = new List<SelectListItem>(); 
                items.Add(new SelectListItem { Text = "Swimming", Value = "1" }); 
                items.Add(new SelectListItem { Text = "Cycling", Value = "2", Selected = true }); 
                items.Add(new SelectListItem { Text = "Running", Value = "3" });         
    
    List<ExerciseType> et = new List<ExerciseType>();
        et.Add(new ExerciseType{Id="1"});
        et.Add(new ExerciseType{Id="2"});
    // the line below uses LINQ to filter out the item with text of "Swimming"            
    var filteredList = from x in items
                        join y in et on x.Value equals y.Id
                        where x.Text != "Swimming"
                        select x;
    ViewData["Testing"] = new SelectList(filteredList, "Value", "Text");
    
