            TransactionOptions options1 = new TransactionOptions();
            options1.IsolationLevel = IsolationLevel.Chaos;
            TransactionOptions options2 = new TransactionOptions();
            options2.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope1 = new TransactionScope(TransactionScopeOption.Required, options1))
            {
                using (TransactionScope scope2 = new TransactionScope(TransactionScopeOption.Required, options2))
                {
                }
             }
        }
