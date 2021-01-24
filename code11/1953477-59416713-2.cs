    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
    	try {
    		string link = e.Uri.ToString();
    		System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
    		processStartInfo.FileName = GetDefaultBrowserOnWin10();
    		processStartInfo.Arguments = link;
    		System.Diagnostics.Process.Start(processStartInfo);
    	} catch (Exception ex) {
    		MessageBox.Show(ex.Message);
    	}
    }
