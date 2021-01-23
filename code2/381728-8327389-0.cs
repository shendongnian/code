    @model Nullable<bool>
    
    @{
        var listItems = new[]
        {   
            new SelectListItem { Value = "null", Text = "Sin Valor" },
            new SelectListItem { Value = "true", Text = "Si" },
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
