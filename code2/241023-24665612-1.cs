           [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            iis = new IisExpressAgent();
            iis.Start("/site:\"WcfService1\" /apppool:\"Clr4IntegratedAppPool\"");
        }
        static IisExpressAgent iis;
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            iis.Stop();
        }
