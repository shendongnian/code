    public object Any(MyRequest request)
    {
        using (var dbTrans = Db.OpenTransaction())
        {
            MyRepository1.Something(Db, request.Id);
            MyRepository2.Something(Db, request.Id);
            //....
            dbTrans.Commit();
        }
    }
