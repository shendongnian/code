    var val = new CustomValidator()
    {
       ErrorMessage = "This is my error message.",
       Display = ValidatorDisplay.None,
       IsValid = false,
       ValidationGroup = vGroup
    };
    val.ServerValidate += (object source, ServerValidateEventArgs args) => 
       { args.IsValid = false; };
    Page.Validators.Add(val);
