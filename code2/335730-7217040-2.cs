          interface IFoo
          {
            void Bar(int j);
          }
          class Foo : IFoo
          {
            public void Bar(int j)
            {
            }
          }
          static void Main(string[] args)
          {
            var bar = typeof(IFoo).GetMethod("Bar");
            var x = Delegate.CreateDelegate(typeof(Action<int>), new Foo(), bar);
          }
