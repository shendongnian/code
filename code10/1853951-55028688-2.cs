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
                    if (element is null) return;
                    AutomationElement childElm = element.FindFirst(TreeScope.Children,
                        new PropertyCondition(AutomationElement.NameProperty, ElementText));
                    if (childElm != null)
                    {
                        (element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern).Close();
                        this.OnElementFound(new EventArgs());
                    }
                });
        public void OnElementFound(EventArgs e)
        {
            Automation.RemoveAllEventHandlers();
            ElementFound?.Invoke(this, e);
        }
    }
