	    [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Set default working directory for NUnit to store allure results
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		}
