        public static void SwitchToIframe(string frameName)
        {
            try
            {
                driver.SwitchTo().Frame(frameName);
            }
            catch (NoSuchFrameException)
            {
                try
                {
                    driver.SwitchTo().Frame(frameName);
                }
                catch (NoSuchFrameException)
                {
                    LogFunctions.WriteError("Could not switch into IFrame");
                    throw;
                }
            }
        }
