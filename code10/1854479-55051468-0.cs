        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);    
            if (Intent.Extras == null)
            {   
                if (string.IsNullOrEmpty(oStaticVariables.MembershipID))
                {
                    var intent = new Intent(this, typeof(LoginView));
                    StartActivity(intent);
                } 
                else
                {
                    intent.PutExtra("NewsListPreviousPosition", "");
                    intent.PutExtra("PTRShown", false);
                    intent.PutExtra("UpdateMsgShown", false);
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                }
                Finish();
            }
            else
            {
                CheckForBackgroundFCMNotifications();
            } 
        }
    
       // Called when app is in background and the app receives notification
        private void CheckForBackgroundFCMNotifications()
        {
             Intent nextActivity = new Intent(this, typeof(NewsNotificationsActivity));
             foreach (var key in Intent.Extras.KeySet())
             {
                    try  // just in case the value is not a string
                    {
                        var value = Intent.Extras.GetString(key);
                        //Log.Debug("", "Key: {0} Value: {1}", key, value);
                        if (key == "NotifyId")
                            nextActivity.PutExtra("NotifyId", value);
                        if (key == "Header")
                            nextActivity.PutExtra("Header", value);
                    catch {}
            }
            StartActivity(nextActivity);
        }
