    if (_webHelper.IsRequestBeingRedirected || _webHelper.IsPostBeingDone)
    {
        //redirection or POST has been done in PostProcessPayment
        return Content("Redirected");
    }
