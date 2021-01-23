    void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      #region handle download error
      string download = null;
      try
      {
        download = e.Result;
      }
    catch (Exception ex)
      {
        MessageBox.Show(AppMessages.CONNECTION_ERROR_TEXT, AppMessages.CONNECTION_ERROR, MessageBoxButton.OK);
      }
    
      // check if download was successful
      if (download == null)
      {
        return;
      }
      #endregion
    	
      // in my example I parse a xml-documend downloaded above		
      // parse downloaded xml-document
      var dataDoc = XDocument.Load(new StringReader(download));
    
      //... your code
    }
