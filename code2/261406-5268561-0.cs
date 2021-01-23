    private Timer t = new Timer();
    private string nextUrl = "";
    private void buttonStart_Click(object sender, EventArgs e)
    {
        t.Interval = 2500;
        t.Tick += new EventHandler(t_Tick);
    }
    void t_Tick(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(nextUrl))
            webBrowser1.Navigate(nextUrl);
        else
        {
            Regex regCaptchaCode = new Regex("src=\\'/pages/captcha\\?t=c&s=([\\d\\w\\W]+)\\'", RegexOptions.IgnoreCase);
            if (regCaptchaCode.IsMatch(webBrowserMain.DocumentText))
            {
                pictureBox1.ImageLocation = @"http://www.clix-cents.com/pages/captcha?t=c&s=" + regCaptchaCode.Match(webBrowserMain.DocumentText).ToString();
            }
        }
    }
    private void webBrowserMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) // This is only way It worked for me.
    {
        if (webBrowserMain.Url.AbsoluteUri == @"http://www.clix-cents.com/pages/clickads")
        {
            Regex regAddId = new Regex("onclick=\\'openad\\(\"([\\d\\w]+)\"\\);", RegexOptions.IgnoreCase); // Find link and click it.
            if (regAddId.IsMatch(webBrowserMain.DocumentText))
            {
                string AddId = regAddId.Match(webBrowserMain.DocumentText).Groups[1].ToString();
                nextUrl = @"http://www.clix-cents.com/pages/clickads?h=" + AddId;
                t.Start();
            }
        }
        else if (webBrowserMain.Url.AbsoluteUri.Contains("http://www.clix-cents.com/pages/clickads?h=")) // up to there everything is ok. But problem starts here.
        {
            nextUrl = "";
            t.Start();
        }
    }
