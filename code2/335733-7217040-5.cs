        class Foo
        {
            public void Bar<T>(T j)
            {
            }
        }
        static void Main(string[] args)
        {
            var bar = typeof(Foo).GetMethod("Bar").MakeGenericMethod(typeof(int));
            var x = Delegate.CreateDelegate(typeof(Action<int>), new Foo(), bar);
        }
