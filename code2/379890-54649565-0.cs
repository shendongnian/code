    public int Add(Transaction transaction)
    {
            using (IDbConnection db = Connection)
            {
                    return (int)db.Insert(transaction);
            }
    }
