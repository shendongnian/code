    from t in db.Table // your C# table / collection here, of course
    where t.ExId == stackoverflow.ExId 
        && (new int[] {1, 2, 3 }).Contains(t.SmId)
    group tby new { t.SmId } into g
    select new {
       SmId = (System.Int32?)g.Key.SmId,
       minEntID = (System.Int32?)g.Min(p => p.EntId)
    }
