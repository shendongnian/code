    class StoreRepository
    {
        public static void SaveOrUpdate(List<Store> stores)
        {
            using (ISession session = FNH_Manager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if(s.Id == 0)
                    { 
                        session.SaveOrUpdate(s);
                    } 
                    transaction.Commit();
                }
            }
        }
    }
