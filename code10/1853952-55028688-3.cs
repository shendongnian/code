    using System;
    using System.Diagnostics;
    using System.Windows.Automation;
    
    public class WindowWatcher
    {
        public delegate void ElementFoundEventHandler(object sender, EventArgs e);
        public event ElementFoundEventHandler ElementFound;
        public WindowWatcher() { }
        public void WatchWindowBySubElementText(string ElementText) => 
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, 
                AutomationElement.RootElement, TreeScope.Subtree, (UIElm, evt) =>
                {
                    AutomationElement element = UIElm as AutomationElement;
                    try {
                        if (element is null) return;
                        AutomationElement childElm = element.FindFirst(TreeScope.Children,
                            new PropertyCondition(AutomationElement.NameProperty, ElementText));
                        if (childElm != null)
                        {
                            (element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern).Close();
                            this.OnElementFound(new EventArgs());
                        }
                    }
                    catch (ElementNotAvailableException) {
                        // Ignore: this exception may be raised when a modal dialog owned 
                        // by the current process is shown, blocking the code execution. 
                        // When the dialog is closed, the AutomationElement may no longer be available
                    }
                });
        public void OnElementFound(EventArgs e)
        {
            Automation.RemoveAllEventHandlers();
            ElementFound?.Invoke(this, e);
        }
    }
