    using System.Windows.Automation;
    
    Automation.AddAutomationEventHandler(
                WindowPattern.WindowClosedEvent,
                AutomationElement.RootElement, // set correct value here
                TreeScope.Children,            // check the value is correct
                (sender, e) =>
                {
                    var element = sender as AutomationElement;
                    if (element.Current.Name != "Form Title")
                        return;
                    Automation.RemoveAllEventHandlers(); // remove event handler
                    
                    // Your code here
                    // CodeToRunAfterWindowClosed();
                });
