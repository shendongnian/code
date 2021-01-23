     public void WaitForElementByLinkText(string linkText) {
                List<string> failedBrowsers = new List<string>();
                foreach (IWebDriver driver in drivers) {
                    try {
                        WebDriverWait wait = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(250));
                        wait.Until((d) => { return d.FindElement(By.LinkText(linkText)).Displayed; });
                    } catch (TimeoutException) {
                        failedBrowsers.Add(driver.GetType().Name + " Link text: " + linkText);
                    }
                }
                Assert.IsTrue(failedBrowsers.Count == 0, "Failed browsers: " + string.Join(", ", failedBrowsers));
            }
