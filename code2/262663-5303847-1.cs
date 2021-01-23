    var col = HttpUtility.ParseQueryString(decodedString);
    var cp = new ConfirmationPage();
    for (var prop in typeof(ConfirmationPage).GetProperties())
    {
        var queryParam = col[prop.Name];
        if (queryParam != null)
        {
             prop.SetValue(cp,queryParam,null);
        }
    }
