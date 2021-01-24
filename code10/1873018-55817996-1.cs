    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [CP.Controladores.ValidateCaptcha()]
    public ActionResult MailDeContacto(FormCollection values, bool 
    CaptchaIsValid)
    {
        // Do something
    }
