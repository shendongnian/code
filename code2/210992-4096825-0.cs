    public virtual void Update(TObj obj)
    {
        using (ITransaction tx = CurrentSession.BeginTransaction())
        {
            CurrentSession.SaveOrUpdate(obj);
            tx.Commit();
        }
    }
