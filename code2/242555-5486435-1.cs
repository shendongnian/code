    private void SendKeys()
    //String sText , String sWindow
    //alternate you can have a parameters 
    {
        string stab = "{TAB}";
        string skey = rtFilename.Text.Trim();
        int iHandle = winApiHelper.FindWindow(null, cboWindows.Text.Trim());
        winApiHelper.SetForegroundWindow(iHandle);                         
        System.Windows.Forms.SendKeys.Send(skey.Trim() + stab.ToString().Trim());
    }
