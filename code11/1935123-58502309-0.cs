        [SetUp]
        public void Setup()
        {
            string s = PackUriHelper.UriSchemePack;
            var current = new Application();
        }
        [Test]
        public void test()
        {
            PackUriHelper.Create(Util.ResourceDictionary.Source);
            
            // have to create vm here because member vm runs before Setup....
        }
