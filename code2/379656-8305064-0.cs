    struct Pair {
        public IOne One { get; set; }
        public ITwo Two { get; set; }
        public Pair(IOne one, ITwo two) : this() {
            One = one;
            Two = two;
        }
    }
    public IQueryable<Pair> Get(ISession s, int color) {
                return from one in s.Query<IOne>()
                       from two in s.Query<ITwo>()
                       where (one.Id == two.OneId) && (two.Color > color)
                       select new Pair(one, two);
            }
