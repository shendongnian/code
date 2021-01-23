    protected void Application_Start(object sender, EventArgs e)
    {
      // In our sample application, we want to use the value of Session["UserEmail"] when our session ends
      SessionEndModule.SessionObjectKey = "UserEmail";
      // Wire up the static 'SessionEnd' event handler
      SessionEndModule.SessionEnd += new SessionEndEventHandler(SessionTimoutModule_SessionEnd);
    }
    
    private static void SessionTimoutModule_SessionEnd(object sender, SessionEndedEventArgs e)
    {
       Debug.WriteLine("SessionTimoutModule_SessionEnd : SessionId : " + e.SessionId);
       // This will be the value in the session for the key specified in Application_Start
       // In this demonstration, we've set this to 'UserEmail', so it will be the value of Session["UserEmail"]
       object sessionObject = e.SessionObject;
     
       string val = (sessionObject == null) ? "[null]" : sessionObject.ToString();
       Debug.WriteLine("Returned value: " + val);
    }
    
