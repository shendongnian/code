          DbTransaction transaction = null;
            try
            {
                try
                {
                    if (this.provider.Connection.State == ConnectionState.Open)
                    {
                        this.provider.ClearConnection();
                    }
                    if (this.provider.Connection.State == ConnectionState.Closed)
                    {
                        this.provider.Connection.Open();
                        flag = true;
                    }
                    transaction = this.provider.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    this.provider.Transaction = transaction;
                    new ChangeProcessor(this.services, this).SubmitChanges(failureMode);
                    this.AcceptChanges();
                    this.provider.ClearConnection();
                    transaction.Commit();
                }
                catch
                {
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                        }
                    }
                    throw;
                }
                return;
            }
            finally
            {
                this.provider.Transaction = null;
                if (flag)
                {
                    this.provider.Connection.Close();
                }
            }
        }
