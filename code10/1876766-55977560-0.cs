    public Other(IClassA ia = null)
    {
         ia = ia ?? new ClassA();
         ia.AMethod();
    }
