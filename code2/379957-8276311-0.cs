        public void Add<T>(T entity)
        {
            using (ISession session = SessionProviderSqLite.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(typeof(T).FullName, entity)
                transaction.Commit();
            }
        }
