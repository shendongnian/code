    using (TransactionScope tsc = new TransactionScope())
    {
        tableAdap.GetData() ;
        //Do your transactional work.
        tableAdap.Update() ;
        tsc.Complete() ;
    }
