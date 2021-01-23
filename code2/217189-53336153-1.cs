    public ActionResult Error(int errorType, string aspxerrorpath)
    {
       if (!string.IsNullOrEmpty(aspxerrorpath)) {
          return RedirectToRoute("Error", errorType);
       }
       switch (errorType) {
          case 404:
               return View("~/Views/Shared/Errors/404.cshtml");
           case 500:
            default:
               return View("~/Views/Shared/Errors/500.cshtml");
        }
    }
