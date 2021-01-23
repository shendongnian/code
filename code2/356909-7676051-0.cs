      public class FooOfDoom
      {
        public string[] Foos = new string[2];
        public string Foo1
        {
          set { Foos[0] = value; }
          get { return Foos[0]; }
        }
        public string Foo2
        {
          set { Foos[1] = value; }
          get { return Foos[1]; }
        }
      }
