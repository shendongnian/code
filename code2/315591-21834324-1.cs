    ...
    var enablingControl = this.NamingContainer.FindControl(ControlThatEnables); 
    if (enablingControl != null) 
    {
        if (enablingControl is HiddenField)
        {
            var hfValue = Page.Request.Form[((HiddenField)enablingControl).UniqueID];
            isValidatorEnabled = hfValue == ControlValueThatEnables;
        }
    }
    
    ...
