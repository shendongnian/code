    class Precompiled<T1, T2> {
      public Precompiled(Expression<Func<T1, T2>> expr) {
        this.Expression = expr;
        this.Function = expr.Compile();
      }
      public Expression<Func<T1,T2>> Expression { get; private set; }
      public Func<T1,T2> Function { get; private set; }
    }
