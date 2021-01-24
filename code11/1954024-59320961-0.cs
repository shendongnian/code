    // in a static class
    public static MyFunction And(this MyFunction f, MyFunction after) =>
        p => {
          Argument copyP = new Argument(p);
          boolean applied = f(copyP) && after(copyP);
          if(applied){
            // boilerplate work
          }
          return applied;
        };
    public static MyFunction Or(this MyFunction f, MyFunction after) =>
        p => {
            var applied = f(p);
            return applied || after(p);
        };
