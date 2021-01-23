    if (!user.IsAuthenticated)
    {
        var result = new ViewResult { ViewName = "Unauthorised" };
        var model = new ViewModel(
            WebApplication.CurrentUser.Translate("msgunauthorisedtitle")
        );
        result.ViewData.Model = model;
        filterContext.Result = result;
        return;
    }
