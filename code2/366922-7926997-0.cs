        /// <summary>
        /// Attempt to close modal windows if there are any.
        /// </summary>
        public static void CloseModalWindows()
        {
            // get the main window
            AutomationElement root = AutomationElement.FromHandle(Process.GetCurrentProcess().MainWindowHandle);
            if (root == null)
                return;
            // it should implement the Window pattern
            object pattern;
            if (!root.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                return;
            WindowPattern window = (WindowPattern)pattern;
            if (window.Current.WindowInteractionState != WindowInteractionState.ReadyForUserInteraction)
            {
                // get sub windows
                foreach (AutomationElement element in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)))
                {
                    // hmmm... is it really a window?
                    if (element.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                    {
                        // if it's ready, try to close it
                        WindowPattern childWindow = (WindowPattern)pattern;
                        if (childWindow.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction)
                        {
                            childWindow.Close();
                        }
                    }
                }
            }
        }
