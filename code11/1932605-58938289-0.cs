c#
[Test]
public void TestAboutWindow()
{
    // Open About window through menu
    _session.FindElementByName("Help").Click();
    _session.FindElementByName("About").Click();
    // Close child window through WindowElement API
    var aboutWindow = _session.FindElementByName("AboutWindow");
    aboutWindow.FindElementByName("Close").Click();
 }
