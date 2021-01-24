    public static void WaitForSuccess(this IWebElement _progressbar)
    {
        for(int second = 0; i <= 30; i++)
        {
            if(_progressbar.GetAttribute("class").Contains("progress-bar-success"))
            return;
            else if(_progressbar.GetAttribute("class").Contains("progress-bar-danger"))
            Assert.Fail("No success");
        Thread.Sleep(1000);
        }
    Assert.Fail("Timeout");
    }
