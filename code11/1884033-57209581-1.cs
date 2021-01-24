    namespace my_namespace
    {
        public sealed partial class LoginPage : Page
        {
            private bool hasFullTextBeenRead = false;
            private object userIdNameProperty = null;
            private void UserId_GotFocus(object sender, RoutedEventArgs e)
            {
                if (hasFullTextBeenRead)
                {
                    UserId.SetValue(AutomationProperties.NameProperty, userIdNameProperty);
                }
                else
                {
                    userIdNameProperty = UserId.GetValue(AutomationProperties.NameProperty);
                    UserId.SetValue(AutomationProperties.NameProperty, 
                        // Add a period so Narrator pauses after reading the logo name.
                        FrameworkElementAutomationPeer.FromElement(Logo)?.GetName() + ". " + 
                        FrameworkElementAutomationPeer.FromElement(WelcomeTo)?.GetName() + " " + 
                        // Add a period so Narrator pauses after reading the service name.
                        FrameworkElementAutomationPeer.FromElement(ServiceName)?.GetName() + ". " + 
                        // Add a period so Narrator pauses after reading the footer.
                        FrameworkElementAutomationPeer.FromElement(Footer)?.GetName() + ". " + 
                        FrameworkElementAutomationPeer.FromElement(UserId)?.GetName());
                    hasFullTextBeenRead = true;
                }
            }
        }
    }
