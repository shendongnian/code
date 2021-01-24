LoginPhase2(){
 foreach (var user in list)
                {
                    if (user.username == Usernamelabel.Text)
                    {
                        if (Usernamelabel.Text == "TesteDetails")
                        {
                            GlobalVariable.Tester = true;
                            Preferences.Set("CId", user.id.ToString());
                            if (WpApiCredentials.token != null) Preferences.Set("Token", WpApiCredentials.token);
                     
                            App.justloggedin = false;
                            Preferences.Set("CUsername", user.username);
                            Preferences.Set("CEmail", user.email);
                            
                            Application.Current.SavePropertiesAsync();
                        }
                        else
                        {
                            GlobalVariable.Tester = false;
                            Preferences.Set("CId", user.id.ToString());
                            if (WpApiCredentials.token != null) Preferences.Set("Token", WpApiCredentials.token);
                            Application.Current.MainPage = new Home();
                            App.justloggedin = false;
                            Preferences.Set("CUsername", user.username);
                            Preferences.Set("CEmail", user.email);
                         
                            Application.Current.SavePropertiesAsync();
                        }
                    }
                
                }
                if (App.justloggedin != true)
                {
                    App.justloggedin = true;
                    DisplayAlert("Logged in", "Login Process Complete. Welcome to Mica Market", "OK");
                    Application.Current.MainPage = new Home();
                }
}
