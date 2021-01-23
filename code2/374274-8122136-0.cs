    using (EFContext c = new EFContext())
    {
        var query = from t in c.MyTable.Include("MyRelations").AsEnumerable()
                select new Pocos.MyTable()
                {
                    MyId = t.MyId,
                    MyField = t.MyField,
                    MyRelationIds = t.MyRelations.Select(mr => mr.MyRelationId).ToList()
                };
        
        return query.ToList();
    }
