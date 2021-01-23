    class Closure { 
      public int x;  
      public Func<int> Nested1() { 
        x++;
        return Func<int>(Nested2);
      }
      public int Nested2() { return x; }
    }
    Func<Func<int>> Foo() {
      var clo = new Closure(10);
      return Func<Func<int>>(clo.Nested1);
    }
