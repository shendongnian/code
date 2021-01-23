        private T GetDataById<T>(Guid Id)
        {
            T obj;
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    obj = session.Get<T>(Id);
                    tx.Commit();
                }
                return obj;
            }
        }
