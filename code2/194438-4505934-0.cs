        [AssemblyInitialize]
        public static void MagicHappensHere(TestContext context) {
            
            PackUriHelper.Create(new Uri("reliable://0"));
        }
