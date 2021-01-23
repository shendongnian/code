    using (WebClient request = new WebClient())
    {
        request.Credentials = new NetworkCredential(txtFTPuser.Text,
                                                    txtFTPpassword.Text);
        request.DownloadFile(url, fullDownloadPath);
        MessageBox.Show("Completed!");
    }
