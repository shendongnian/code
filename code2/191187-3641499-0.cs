    public delegate void SetWebAddressDelegate ( WebBrowser browser, Uri newUrl);
    
    public void SetWebAddress ( WebBrowser browser, Uri newUrl )
    {
        if (browser.InvokeRequired)
            browser.Invoke(new SetWebAddressDelegate(SetWebAddress), browser, newUrl);
        else
            browser.Url = newUrl;
    }
