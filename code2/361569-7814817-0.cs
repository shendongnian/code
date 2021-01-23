     public ActionResult Create()
            {
                ViewData["Genders"] = new SelectList(horseTracker.Genders, "Id", "Name");
                ViewData["LegTypes"] = new SelectList(horseTracker.LegTypes, "Id", "Name");
                ViewData["Characters"] = new SelectList(horseTracker.Characters, "Id", "Name");
                ViewData["Sires"] = new SelectList(horseTracker.Horses.Where(h => h.Gender.Name.Equals("Male") && h.Retired.Equals(true)), "Id", "Name");
                ViewData["Dams"] = new SelectList(horseTracker.Horses.Where(h => h.Gender.Name.Equals("Female") && h.Retired.Equals(true)), "Id", "Name");
    
                return View();
            }
    <div class="editor-label">
                @Html.LabelFor(horse => horse.GenderId)
            </div>
            <div class="editor-field">
    
                @Html.DropDownList("Id", (SelectList)ViewData["Genders"])
    
                @Html.ValidationMessageFor(horse => horse.GenderId)   
            </div>
