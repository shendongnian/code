AutomationFocusChangedEventHandler focusHandler = null;
/// <summary>
/// Create an event handler and register it.
/// </summary>
public void SubscribeToFocusChange()
{
    focusHandler = new AutomationFocusChangedEventHandler(OnFocusChange);
    Automation.AddAutomationFocusChangedEventHandler(focusHandler);
}
/// <summary>
/// Handle the event.
/// </summary>
/// <param name="src">Object that raised the event.</param>
/// <param name="e">Event arguments.</param>
private void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
{
    AutomationElement focusedElement = src as AutomationElement;
    // TODO Add event handling code.
    // The arguments tell you which elements have lost and received focus.
}
/// <summary>
/// Cancel subscription to the event.
/// </summary>
public void UnsubscribeFocusChange()
{
    if (focusHandler != null)
    {
        Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.automation.automation.addautomationfocuschangedeventhandler?view=netframework-4.8
