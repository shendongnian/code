    using(var db = new tranEntities())
    {
        var t = new TranBaseClass();
        t.tranDescription = @"Some Description";
        try
        {
            db.Trans.Add(new Tran(t));
        }
        catch (System.Data.Entity.Infrastructure.DbUpdateException)
        {
            db.TransError.Add(new TranError(t));
        }
    }
