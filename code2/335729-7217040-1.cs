          interface IFoo
          {
            void Bar<T>(T j);
          }
          class Foo : IFoo
          {
            public void Bar<T>(T j)
            {
            }
          }
          static void Main(string[] args)
          {
            var bar = typeof(IFoo).GetMethod("Bar").MakeGenericMethod(typeof(int));
            var x = Delegate.CreateDelegate(typeof(Action<int>), new Foo(), bar);
          }
