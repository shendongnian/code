    @model ViewModels.UserViewModel
    @{
        ViewBag.Title = "Test";
    }
    
    <h2>Test</h2>
    <p>
    @Html.DropDownListFor(model => model.User.DivisionId, new SelectList(Model.Divisions, "DivisionId", "DivisionName"),  "-- Select Division --") 
    @Html.ValidationMessageFor(model => model.User.DivisionId)  
    </p>
