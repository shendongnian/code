    Dictionary<Uri, string> loginAddresses = new Dictionary<Uri, string>()
    {
        { new Uri("https://kite.zerodha.com"), "testId|TestPassword1" },
        { new Uri("https://www.someothersite.com/login") "user@domain.com|ThePassword1" }
    };
    private async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var wb = sender as WebBrowser;
        if (wb.ReadyState != WebBrowserReadyState.Complete || wb.Document.Forms.Count == 0) return;
        if (loginAddresses.TryGetValue(wb.Url, out string values)) {
            var usrPwd = values.Split('|');
            await DoWebFormLogin(wb, usrPwd[0], usrPwd[1]);
        }
    }
    private async Task DoWebFormLogin(WebBrowser wb, string usrId, string pwd)
    {
        bool userIDSet = false;
        bool passwordSet = false;
        var inputElms = wb.Document.GetElementsByTagName("INPUT").OfType<HtmlElement>().ToList();
        if (inputElms.Count < 2) return;
        foreach (var elm in inputElms)
        {
            if (elm.GetAttribute("type").Equals("text")) {
                elm.Focus();
                await Task.Delay(50);
                elm.InnerText = usrId;
                elm.SetAttribute("value", usrId);
                userIDSet = true;
            }
            if (elm.GetAttribute("type").Equals("password")) {
                elm.Focus();
                await Task.Delay(50);
                elm.InnerText = pwd;
                elm.SetAttribute("value", pwd);
                passwordSet = true;
            }
            if (userIDSet && passwordSet) {
                var buttonElms = wb.Document.GetElementsByTagName("BUTTON").OfType<HtmlElement>().ToList();
                foreach (var button in buttonElms) {
                    if (button.GetAttribute("type").Equals("submit")) {
                        button.Focus();
                        await Task.Delay(50);
                        button.InvokeMember("click");
                        break;
                    }
                }
            }
        }
    }
