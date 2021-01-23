    @model Nullable<bool>
    @{
        var listItems = new[]{
            new SelectListItem { Value = "null", Text = "Sin Valor", Selected = !Model.HasValue },
            new SelectListItem { Value = "true", Text = "Si", Selected = Model.HasValue && Model.Value },
            new SelectListItem { Value = "false", Text = "No", Selected = Model.HasValue && !Model.Value}
        };
    }
    @if (ViewData.ModelMetadata.IsNullableValueType)
    {
    
        @Html.DropDownList("", listItems)
    }
    else
    {
        @Html.CheckBox("", ViewData.Model.Value)
    }
