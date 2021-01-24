    public ActionResult Logout()
     {
       Session.Abandon();
       Session.Clear();
       return RedirectToAction("LoginPage", "Login");
     }
