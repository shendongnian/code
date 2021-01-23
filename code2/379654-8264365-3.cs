    static Expression<Func<Tuple<IOne, ITwo>, bool>> MyWhereExpression2(int color) {
        return t => (t.Item1.Id == t.Item2.OneId) && (t.Item2.Color > color);
    }
    int color = 100;
    IQueryable<IOne> records = (from one in s.Query<IOne>()
                                from two in s.Query<ITwo>()
                                select Tuple.Create(one, two))
                                .Where(MyWhereExpression2(color))
                                .Select(t => t.Item1);
