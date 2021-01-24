private void CreateWindowTitle()
{
    windowTitle = "Task";
}
        
public Task ShouldFocusTaskWindow()
{
    var popup = GetBrowserName();
    FocusWindowOrPopup(windowTitle);
    WaitUntilVisible(By.Id("Content_ctrlTaskControl_lblCaseNumber"));
    return this;
}
