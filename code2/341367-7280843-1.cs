    DateTime dtServer=DateTime.Now;
    DateTime dtClient=DateTime.Parse(Request.QueryString["dtStr"]); // Or Request.Form
    double requestTimeDelta=10f; // max time in seconds between client starts the request,
                                 // and this code lines is executed.
    double secondsDelta=2f;
    DateTime max=dtClient.AddSeconds(requestTimeDelta+secondsDelta);
    DateTime min=dtClient.AddSeconds(-secondsDelta);
    if (max>=dtServer && min<=dtServer) {
      // time is correct
    }
    else
    {
      // time is incorrect
    }
