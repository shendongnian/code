    public static bool FindElement
            {
                get
                {
                    try
                    {
           WebDriverWait wait = new WebDriverWait(Driver.BrowserInstance, TimeSpan.FromSeconds(10));
    var inputspcmodel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector($"div[id ='modelSearch-container'] div[class='k-widget k-multiselect k-multiselect-clearable'] div input")));
    inputspcmodel.Click();
    return true;
    }
    catch (Exception ex)
                    {
                        Logging.Error("Not able to find element " + ex.ToString());
                        Logging.ErrorScreenshot();
                    }
                    return false;
                }
    
            }
