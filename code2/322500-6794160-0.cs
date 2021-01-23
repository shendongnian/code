        /// <summary>
        /// Asynchronous Callback For Get Users
        /// </summary>
        private void UserAgentGetCompleted(object sender, List<UserDto> users)
        {
            
             //Make sure we are on the UI thread
              this.Dispatcher.BeginInvoke(() => SetUsers(users));
        }
