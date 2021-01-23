     public static bool WaitForElement(String waitingElement, DefaultSelenium selenium)
            {
                var isElementExists = selenium.IsElementPresent(waitingElement);
                if (!isElementExists)
                {
                    Thread.Sleep(50);
                    return WaitForElement(waitingElement, selenium);
                }
                else
                {
                    return isElementExists;
                }
            }
