    public bool myMethod()
    {
        if (ctx == null)
        {
            using (ctx = new Entities())
            {
                using (var dbTran = ctx.Database.BeginTransaction())
                {
                    Update(ctx); // you need to return the values here
                    dbTran.Commit();
                }
            }
        }
        else
        {
            if (ctx.Database.CurrentTransaction == null)
            {
                using (var dbTran = ctx.Database.BeginTransaction())
                {
                    Update(ctx); // you need to return the values here
                    dbTran.Commit();
                }
            }
            else
            {
                Update(ctx); // you need to return the values here
            }
        }
    }
    private void Update(DbContext context)
    {
        List<MyObject> rows = MyObject.getRows(id, context);
        foreach (MyObject ier in rows)
        {
            MyObject oldObj = MyObject.GetEntity(ier.ID, context);
            List<p_Result> res = context.p_RecalcCost(ier.ID).ToList<p_Result>();
            decimal oldCost = oldObj.Cost;
            decimal newCost = (decimal) res[0].Cost;
        }
    }
