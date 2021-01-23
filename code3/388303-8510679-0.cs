        class MyTransaction
        {
            private readonly SqlTransaction _transaction;
            public MyTransaction(SqlConnection conn)
            {
                _transaction = conn.BeginTransaction();
            }
            public SqlTransaction Transaction
            {
                get
                {
                    return _transaction;
                }
            }
            public static implicit operator SqlTransaction(MyTransaction t)
            {
                return t.Transaction;
            }
        }
