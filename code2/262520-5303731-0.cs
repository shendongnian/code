    @{
        object modelValue = string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            ViewData.ModelMetadata.DisplayFormatString, 
            ViewData.ModelMetadata.Model
        );
    }
    @Html.TextBox("", modelValue, new { @class = "text-box single-line" })
