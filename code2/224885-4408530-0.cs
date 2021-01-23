    protected override void InitializeCulture()
    {
        base.InitializeCulture();
    
        string language = Request.Form["ddlLanguages"];
        if (!String.IsNullOrEmpty(language) {
            Culture = UICulture = language;
        }
    }
