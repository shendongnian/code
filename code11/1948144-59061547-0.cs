    <Login OnLogin="LoginComplete"></Login>
    /// <summary>
    /// This method returns the LoginResponse object 
    /// </summary>
    /// <param name="loginResponse"></param>
    private void LoginComplete(LoginResponse loginResponse)
    {
        // if the login was successful
        if (loginResponse.Success)
        {
            // Set the player
            player = loginResponse.Player;
            // refresh the UI
            this.StateHasChanged();
        }
    }
