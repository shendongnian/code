    double a = 1.0;
    double b = 2.0;
    while (true)
    {
      var calculate = "(lambda (a b) (+ a b))".Eval<Callable>();
      System.Threading.Tasks.Parallel.For(0, 1000, _ =>
      {
        for (int i = 0; i < 1000; i++) { calculate.Call(a, b); }
      });
      Console.Write(".");
    }
