        private readonly TransactionScope _scope;
        public MyTests()
        {
            var options = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.Snapshot
            };
            _scope = new TransactionScope(TransactionScopeOption.Required, options,  TransactionScopeAsyncFlowOption.Enabled);
          }
          [TestCleanup]
          public void Cleanup()
          {
              _scope.Dispose();
          }
