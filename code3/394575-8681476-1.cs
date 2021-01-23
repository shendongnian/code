    protected void Login_MouseClickHandler (object obj ,MouseClickEventArgs e) {
        // login logic
        // this would be the logic you say is "inside the login button"
    }
    
    protected void Download_MouseClickHandler (object obj ,MouseClickEventArgs e) {
        // download logic
    }
    
    
    // pseudo code
    // note that there is only one button
    if process is login then
        theButton.text = "login"
        theButton.MouseClick += new MouseClickEventHandler(Login_MouseClickHandler)
    else  
       button.text = "download"
       theButton.MouseClick += new MouseClickEventHandler (Download_MouseClickHandler)
    end if
