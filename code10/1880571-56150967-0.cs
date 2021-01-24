csharp
async Task SignInProcedure(object sender, EventArgs e) //function called when pressing the signin button
        {
            
            User user = new User(Entry_Username.Text, Entry_Password.Text); //putting username and password entered by the user in the entry box
            if (user.CheckInformation())//checks if the boxes are empty
            {
                try
                {
                    var result = await App.RestService.Login(user);//RestService class
                    await App.Current.MainPage.DisplayAlert("Login", "Login Successful", "Oke");
                    if (result.access_token != null)
                    {
                        App.UserDatabase.SaveUser(user);
                    }
                }
                catch (Exception ex)
                {
                   
                    System.Diagnostics.Debug.WriteLine(ex);
                }
When changing void to Task I get this error : `Position 12:54. Signature (return type) of EventHandler "SmartLockApp.Views.LoginPage.SignInProcedure" doesn't match the event type`
And also, if I don't change void to Task, I can't find the error in the console
