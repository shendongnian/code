    @using MvcTest.Models
    @model Gender
    @{
        var genders = from Gender g in Enum.GetValues(typeof(Gender))
                      select new { Value = g, Text = g.ToString() };
    
        var sl = new SelectList(genders, "Value", "Text");
    }
    @Html.DropDownList(string.Empty, sl, "--Select--")
