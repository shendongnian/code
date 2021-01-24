        public DbError Save<T>(T obj) where T : class
        {
            GeneralExecuteAction((s) =>
            {
                s.Save(obj); //s is nHibernate session
                return true;
            });
            return lastDbError;
        }
