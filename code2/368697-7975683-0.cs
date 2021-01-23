       if (!session.Transaction.IsActive)
        {
            TResult result;
            using (var tx = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity)//Save: 1
                tx.Commit();
            }
            return result;
        } else {
            session.SaveOrUpdate(entity) //Save: 2
        }
