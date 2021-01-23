    class Pair
    {
        public IOne One { get; set; }
        public ITwo Two { get; set; }
    }
    static Expression<Func<Pair, bool>> MyWhereExpression2(int color) {
        return p => (p.One.Id == p.Two.OneId) && (p.Two.Color > color);
    }
    int color = 100;
    IQueryable<IOne> records = (from one in s.Query<IOne>()
                                from two in s.Query<ITwo>()
                                select new Pair { One = one, Two = two })
                                .Where(MyWhereExpression2(color))
                                .Select(t => t.Item1);
  
