                try
                {
                    control = Driver.FindElementByAccessibilityId("loginPage");
                }
                catch (WebDriverException ex)
                {
                    // No login page found, your in the home page.
                    // Code for logging out here.
                }
