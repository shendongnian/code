    var properties = typeof(EFType).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (var property in properties)
    {
        var control = (DropDownList)rep1.FindControl("ddlControl" + property.Name);
        property.SetValue(efObject, control.SelectedValue, null);
    }
