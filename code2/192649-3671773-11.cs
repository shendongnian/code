    class Diff
    {
        public readonly double d;
        public readonly Lazy<Diff> df;
        public Diff(double d, Lazy<Diff> df)
        {
            this.d = d;
            this.df = df;
        }
    }
    class DiffClass : Floating<Diff>
    {
        public static readonly DiffClass Instance = new DiffClass();
        private static readonly Diff zero = new Diff(0.0, new Lazy<Diff>(() => DiffClass.zero));
        private DiffClass() { }
        public Diff Zero { get { return zero; } }
        public Diff Add(Diff a, Diff b) { return new Diff(a.d + b.d, new Lazy<Diff>(() => Add(a.df.Value, b.df.Value))); }
        public Diff Subtract(Diff a, Diff b) { return new Diff(a.d - b.d, new Lazy<Diff>(() => Subtract(a.df.Value, b.df.Value))); }
        public Diff Multiply(Diff a, Diff b) { return new Diff(a.d * b.d, new Lazy<Diff>(() => Add(Multiply(a.df.Value, b), Multiply(b.df.Value, a)))); }
        ...
    }
