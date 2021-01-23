    void Session_End(object sender, EventArgs e) 
        {
            Session.Abandon();
            // Code that runs when a session ends.
        }
    void Application_End(object sender, EventArgs e) 
        {
            Session.Abandon(); 
            //  Code that runs on application shutdown    
        }
