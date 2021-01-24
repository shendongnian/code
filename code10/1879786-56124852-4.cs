        /// <summary>
        /// Gets a UI element based on a AutomationId.
        /// </summary>
        /// <param name="automationId">The AutomationId is a unique value that can be found with UI inspector tools.</param>
        /// <param name="controlName">The name of the UI element.</param>
        /// <param name="timeOut">TimeOut in milliseconds</param>
        /// <returns></returns>
        protected WindowsElement GetElement(string automationId, string controlName, int timeOut = 10000)
        {
            bool iterate = true;
            WindowsElement control = null;
            _elementTimeOut = TimeSpan.FromMilliseconds(timeOut);
            timer.Start();
            while (timer.Elapsed <= _elementTimeOut && iterate == true)
            {
                try
                {
                    control = Driver.FindElementByAccessibilityId(automationId);
                    iterate = false;
                }
                catch (WebDriverException ex)
                {
                    LogSearchError(ex, automationId, controlName);
                }
            }
            timer.Stop();
            Assert.IsFalse(timer.Elapsed > _elementTimeOut, "Timeout Elapsed, element not found.");
            timer.Reset();
            return control;
        }
