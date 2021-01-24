     //switch to the iframe name -
     public static void SwitchToIframe(string frameName)
        {
            try
            {
                Driver.SwitchTo().Frame(frameName);
            }
            catch (NoSuchFrameException)
            {
                try
                {
                    Driver.SwitchTo().Frame(frameName);
                }
                catch (NoSuchFrameException)
                {
                    Console.WriteLine("Could not switch to IFrame");
                    throw;
                }
            }
        }
       //going back to main content when completed with iframe 
        public static void SwitchToMainContent()
        {
            Driver.SwitchTo().DefaultContent();
        }
       //If the iframe closes automatically, you still need to get back to the main window
             public static void GoToMainHandle()
        {
            var handles = Driver.WindowHandles;
            foreach (var handle in handles)
            {
                Driver.SwitchTo().Window(handle);
                break;
            }
        }
