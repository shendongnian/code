        [AfterScenario]
        public void CloseBrowserAfterScenario()
        {
            string driver_process_name = null;
            string browser_process_name = null;
            switch (browser)
            {
                case "Chrome":
                    driver_process_name = "chromedriver.exe";
                    break;
                case "IEX64":
                case "IEX86":
                    driver_process_name = "IEDriverServer.exe";
                    break;
                case "Edge":
                    driver_process_name = "MicrosoftWebDriver.exe";
                    browser_process_name = "MicrosoftEdge.exe";
                    break;
                case "Firefox":
                    driver_process_name = "geckodriver.exe";
                    break;
                default:
                    LogMessage(browser + "is not found or not supported... Please update the TestUI.dll.Config File");
                    break;
            }
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(driver_process_name);
            foreach (System.Diagnostics.Process app_process in process)
            {
                if (!string.IsNullOrEmpty(app_process.ProcessName))
                {
                    try
                    {
                        app_process.Kill();
                    }
                    catch
                    {
                        FunctionalUtil.LogMessage("app_process.Kill(); failed in CloseBrowserAfterScenario");
                    }
                }
            }
