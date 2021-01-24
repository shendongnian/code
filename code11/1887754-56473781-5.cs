    var formsApp = new App();
    LoadApplication(formsApp);
    if (Intent.Data != null)
    {
        var host = Intent.Data.EncodedAuthority;
        var parameter = Intent.Data.GetQueryParameter("destination");
    
        formsApp.MovePage(parameter);
    }
