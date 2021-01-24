    protected bool FocusWindowOrPopup(string windowTitle)
        {
            for (var i = 1; i <= 20; i++)
            {
                try
                {
                    foreach (var window in Context.WebDriver.WindowHandles)
                    {
                        Context.WebDriver.SwitchTo().Window(window);
                        string titl = Context.WebDriver.Title;
                        if (Context.WebDriver.Title.Equals(windowTitle))
                        {
                            return true;
                        }                                 
                    }
                }
                catch
                {
                    //return false;
                }
                Thread.Sleep(500);
            }
            throw new Exception($"Could not focus window: {windowTitle}");
        }
