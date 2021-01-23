        [TestCleanup]
        public void TearDown()
        {
            Dispatcher.CurrentDispatcher.InvokeShutdown();
        }
