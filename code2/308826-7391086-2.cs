    [HttpPost]
    public ActionResult SignIn(User data)
    {
      // authenticate
      return RedirectToAction("AfterSignedIn", new { sessionId = Session.SessionID, id = "my id" } );
    }
