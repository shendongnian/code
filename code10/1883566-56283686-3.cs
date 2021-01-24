    private void btnUpload_Click(object sender, EventArgs e)
    {
        if (backgroundWorker.IsBusy)
           return;
          string dir = "C:\\Users\\bluevels\\Pictures\\";
          string[] files = Directory.GetFiles(dir);
         _inputParameter.Username = txtUserName.Text;
         _inputParameter.Password = txtPassword.Text;
         _inputParameter.Server = txtServer.Text;
         _inputParameter.FileName = fi.Name;
         _inputParameter.FullName = fi.FullName;
         backgroundWorker.RunWorkerAsync(files);
    }
