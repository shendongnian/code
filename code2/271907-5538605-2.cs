    public Top_Address GetTop_AddressById(IDComposite_TopAddress id)
    {
        if (!oracle)
        {
            return session.CreateCriteria(DB, typeof(Top_Address))
               .Add(Restrictions.Eq("ID.TnrAddress", addressID))
               .Add(Restrictions.Eq("ID.TopIdentity.tnrId", tnrID))
               .Add(Restrictions.Eq("AddressType", 'R')) .UniqueResult<Top_Address>();
        }
        else 
        {
            return session.CreateCriteria(DB, typeof(Top_Address))
               .Add(Restrictions.Eq("TnrAddress", addressID))
               .Add(Restrictions.Eq("AddressType", 'R')) .UniqueResult<Top_Address>();
        }
    }
