    private class Closure
    {
      public op Helper(string head, double tail, op op)
      {
        return op == op.add ? Int32.Parse(head) + Convert.ToInt32(tail) : 
        Int32.Parse(head) - Convert.ToInt32(tail);
      }
    }
    Func<op, int> combo(string head, double tail)
    {
      Closure c = new Closure();
      return (op op) => c.Helper(head, tail, op);
    }
