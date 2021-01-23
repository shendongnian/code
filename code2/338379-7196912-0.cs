    public override void ExecuteResult(ControllerContext context) {
        if (context == null) {
            throw new ArgumentNullException("context");
        }
        if (context.IsChildAction) {
            throw new InvalidOperationException(MvcResources.RedirectAction_CannotRedirectInChildAction);
        }
        string destinationUrl = UrlHelper.GenerateUrl(RouteName, null /* actionName */, null /* controllerName */, RouteValues, Routes, context.RequestContext, false /* includeImplicitMvcValues */);
        if (String.IsNullOrEmpty(destinationUrl)) {
            throw new InvalidOperationException(MvcResources.Common_NoRouteMatched);
        }
        context.Controller.TempData.Keep();
        if (Permanent) {
            context.HttpContext.Response.RedirectPermanent(destinationUrl, endResponse: false);
        }
        else {
            context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
        }
    }
