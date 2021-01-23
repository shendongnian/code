    @model Nullable<bool>
    
    @{
        var listItems = new[]
        {   
            new SelectListItem { Value = "null", Text = "Not Set" },
            new SelectListItem { Value = "true", Text = "Yes" },
            new SelectListItem { Value = "false", Text = "No" }
        };  
    }
    
    @if (ViewData.ModelMetadata.IsNullableValueType)
    {
        @Html.DropDownList("", new SelectList(listItems, "Value", "Text", Model))
    }
    else
    {
        @Html.CheckBox("", Model.Value)
    }
