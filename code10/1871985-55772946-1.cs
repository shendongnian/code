    public virtual ActionResult Register(string returnUrl, string invitationCode = null,
                string emailAddressOrMobileNumber = null)
            {
                if (Request.IsAuthenticated) return RedirectToAction(MVC.Home.Index());
                
    }
    return Redirect(Url.RouteUrl(new { controller = "Controller", action = "Action" }) + "#bottom");
    }
 
