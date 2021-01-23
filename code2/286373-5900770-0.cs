    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions()
                    { 
                        IsolationLevel = System.Transactions.IsolationLevel.Serializable,
                        Timeout = TimeSpan.FromSeconds(120)
                    }))
