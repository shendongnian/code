        private Dictionary<string, DateTime> _loggedInUsers = new Dictionary<string, DateTime>(); //need to add this at top of file:  using System.Collections.Generic;
        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
             {
                    if (string.IsNullOrWhiteSpace(IDTextBox.Text)) //usually better than comparing with ""
                    {
                        FlashMessage.Text = "No ID Entered";
                        return;
                    }
                    var user = IDTextBox.Text.Trim(); //remove header/trailing spaces
                    IDTextBox.Clear();                //might as well do this now
                    if(_loggedInUsers.ContainsKey(user))
                    {
                        //how long were they logged in?
                        TimeSpan ts = (DateTime.Now - _loggedInUsers[user]);
                        _loggedInUsers.Remove(user); //log them out
                        FlashMessage.Text = $"{user} successfully logged out at {DateTime.Now}, you were logged in for {ts.TotalHours} hours, which is also {ts.TotalSeconds}. You earned {ts.TotalHours * 200} at your rate of 200$/hr";
                    }
                    else 
                    {   
                        _loggedInUsers[user] = DateTime.Now; //log them in at this time
                        FlashMessage.Text = $"{user} successfully logged in. Go do some work and then log out and I'll tell you how long you were";
                    }
              }
        }
