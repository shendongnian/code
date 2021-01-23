    var fb = new FacebookClient(_accessToken);
    fb.GetCompleted += (o, args) =>
                           {
                               if (args.Error == null)
                               {
                                   var me = (IDictionary<string, object>)args.GetResultData();
                                   Dispatcher.BeginInvoke(
                                       () =>
                                       {
                                           FirstName.Text = "First Name: " + me["first_name"];
                                           LastName.Text = "Last Name: " + me["last_name"];
                                       });
                               }
                               else
                               {
                                   Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                               }
                           };
    fb.GetAsync("me");
