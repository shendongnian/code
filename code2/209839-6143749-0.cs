    public virtual ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
            foreach (var cookie in Request.Cookies.AllKeys)
		    {
                Request.Cookies.Remove(cookie);
		    }
            foreach (var cookie in Response.Cookies.AllKeys)
            {
                Response.Cookies.Remove(cookie);
            }
			return RedirectToAction(MVC.Home.Index());
		}
