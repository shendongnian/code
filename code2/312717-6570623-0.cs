    if (App._loggedIn)
                {
                    fbClient = new FacebookClient(App._accessToken);
    
                    fbClient.GetCompleted +=
                     (o, arg) =>
                     {
                         if (arg.Error == null)
                         {
                             var result = (IDictionary)arg.GetResultData();
    
                             // Get user name
                             this.userName = result["name"].ToString();
    
                             Dispatcher.BeginInvoke(() => this.DataContext = this);
                         }
                         else
                         {
                             MessageBox.Show(arg.Error.Message);
                         }
                     };
    
                     fbClient.GetAsync("/me", new Dictionary{{"fields","id,name,first_name,last_name,picture"} , {"access_token", App._accessToken}});
                }
