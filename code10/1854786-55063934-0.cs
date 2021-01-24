        /// <summary>
        /// Enums the notification icons in the Tray.
        /// </summary>
        /// <returns>List of Notification Icons from the Tray.</returns>
        public static IEnumerable<AutomationElement> EnumNotificationIcons()
        {
            var userArea = AutomationElement.RootElement.Find(UINotificationAreaConstants.UserPromotedNotificationArea);
            if (userArea != null)
            {
                foreach (var button in userArea.EnumChildButtons())
                {
                    yield return button;
                }
                foreach (var button in userArea.GetTopLevelElement().Find(UINotificationAreaConstants.SystemPromotedNotificationArea).EnumChildButtons())
                {
                    yield return button;
                }
            }
            var chevron = AutomationElement.RootElement.Find(UINotificationAreaConstants.NotificationChevron);
            if (chevron != null && chevron.InvokeButton())
            {
                var elm = AutomationElement.RootElement.Find(
                                    UINotificationAreaConstants.OverflowNotificationArea);
                WaitForElm(elm);
                foreach (var button in elm.EnumChildButtons())
                {
                    yield return button;
                }
            }
        }
        /// <summary>
        /// Waits for elm to be ready for processing.
        /// </summary>
        /// <param name="targetControl">The target control.</param>
        /// <returns>The WindowPattern.</returns>
        private static WindowPattern WaitForElm(AutomationElement targetControl)
        {
            WindowPattern windowPattern = null;
            try
            {
                windowPattern =
                    targetControl.GetCurrentPattern(WindowPattern.Pattern)
                    as WindowPattern;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the WindowPattern control pattern
                return null;
            }
            // Make sure the element is usable.
            if (!windowPattern.WaitForInputIdle(10000))
            {
                // Object not responding in a timely manner
                return null;
            }
            return windowPattern;
        }
