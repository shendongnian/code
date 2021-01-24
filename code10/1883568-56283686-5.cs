    class FtpSetting
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FileName { get; set; }
        public string FullName { get; set; }
        public string[] Files { get; set; }
    }
    private void btnUpload_Click(object sender, EventArgs e)
    {
        if (backgroundWorker.IsBusy)
           return;
          string dir = "C:\\Users\\bluevels\\Pictures\\";
          string[] files = Directory.GetFiles(dir);
         _inputParameter.Username = txtUserName.Text;
         _inputParameter.Password = txtPassword.Text;
         _inputParameter.Server = txtServer.Text;
         _inputParameter.Files = files;
         backgroundWorker.RunWorkerAsync(_inputParameter);
    }
