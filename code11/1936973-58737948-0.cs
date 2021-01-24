    sProxyIP = "154.5.5.5";
    sProxyUser = "user here";
    sProxyPass = "pass here";
    sProxyPort = 4444;
    
    //Set proxy
    profile.SetPreference("network.proxy.socks", sProxyIP);
    profile.SetPreference("network.proxy.socks_port", sProxyPort);
    
    //deal with proxy auth
    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(0);
    WebsiteOpen(@"https://somewebsite.com/");
    AuthInProxyWindow(sProxyUser, sProxyPass);
    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
    void ProxyAuthWindow(string login, string pass)
    {
        try
        {   
            //wait for the auth window
            var sHwnd = AutoItX.WinWait("Authentication Required", "", 2);
            AutoItX.WinSetOnTop("Authentication Required", "", 1);
    
            //we are using Windows UIA so we make sure we got the right auth
             //dialog(since there will be multiple threads we can easily hit the wrong one)
            var proxyWindow = AutomationElement.RootElement.FindFirst(TreeScope.Subtree,
                new PropertyCondition(AutomationElement.ClassNameProperty, "MozillaDialogClass"));
            string hwnd = "[handle:" + proxyWindow.Current.NativeWindowHandle.ToString("X") + "]";
            AutoItX.ControlSend(hwnd, "", "", login, 1);
            AutoItX.ControlSend(hwnd, "", "", "{TAB}", 0);
            AutoItX.ControlSend(hwnd, "", "", pass, 1);
            AutoItX.ControlSend(hwnd, "", "", "{ENTER}", 0);
        }
        catch
        {
    
        }
    
    
    }
