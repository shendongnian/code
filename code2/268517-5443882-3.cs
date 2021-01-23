    @{
        var visible = false;
        if (ViewData.ModelMetadata.AdditionalValues.ContainsKey("RequiredRole"))
        {
            var role = (string)ViewData.ModelMetadata.AdditionalValues["RequiredRole"];
            visible = User.IsInRole(role);
        }
    }
    @if (visible)
    {
        @Html.TextBox(
            "", 
            ViewData.TemplateInfo.FormattedModelValue,
            new { @class = "text-box single-line" }
        )
    }
