    // in codebehind
    public string GetIsVisible(bool isDefault)
    {
        return (isDefault) ? "false" : "true";
    }
    // in web form...
    Visible='<%# GetIsVisible(DataBinder.Eval("IsDefault")) %>'
