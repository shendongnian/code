    from t in db.Table // your C# table / collection here, of course
    where t.ExId == stackoverflow.ExId 
        && (new int[] {1, 2, 3 }).Contains(t.SmId)
    group t by new { t.SmId } into g
    select new {
       SmId = g.Key.SmId,
       minEntID = g.Min(p => p.EntId)
    }
