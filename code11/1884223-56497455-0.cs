    var query = new Query("Countries");
    foreach (Group group in groups)
    {
        query.OrWhere(q => {
        foreach (Condition c in group.Conditions)
        {
            q.OrWhere(c.Field, c.Operator, c.Value);
        }
        return q;
        });
    }
    query.Where("Id", "=", 10);
