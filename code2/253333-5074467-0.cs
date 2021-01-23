      class AuthUserData
      {
        public string Name;
        public string Password;
      }
      private void button1_Click(object sender, EventArgs e)
      {
         var authData = new AuthUserData() { Name = textBox1.Text, Password = textBox2.Text };
         worker.RunWorkerAsync(authData);
      }
      void worker_DoWork(object sender, DoWorkEventArgs e)
      {
         // On the worker thread...cannot make UI calls from here.
         var authData = (AuthUserData)e.Argument;
         UserManagement um = new UserManagement(sm.GetServerConnectionString());
         e.Result = um;
         e.Cancel = um.AuthUser(textBox1.Text, textBox2.Password));
      }
      void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         // Back on the UI thread....UI calls are cool again.
         var result = (UserManagement)e.Result;
         if (e.Cancelled)
         {
            // Do stuff if UserManagement.AuthUser succeeded.
         }
         else
         {
            // Do stuff if UserManagement.AuthUser failed.
         }
      }
