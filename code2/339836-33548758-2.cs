        public Int32 GetNextId()
        {
            Int32 id = 0;
            using (var transaction = Session.BeginTransaction())
            {
                id = Session.CreateSQLQuery("insert IdSequence output inserted.id default values").UniqueResult<Int32>();
                transaction.Rollback();
            }
            return id;
        }
