     void Channel_Faulted(object sender, EventArgs e)
     {
         Logout((IContextChannel)sender);
     }
     protected void Logout(IContextChannel channel)
     {
            string sessionId = null;
            if (channel != null)
            {
                sessionId = channel.SessionId;
            }
          [...]
     }
