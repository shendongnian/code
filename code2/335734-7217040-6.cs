        class Foo
        {
            public void Bar(int j)
            {
            }
        }
        static void Main(string[] args)
        {
            var bar = typeof(Foo).GetMethod("Bar");
            var x = Delegate.CreateDelegate(typeof(Action<int>), new Foo(), bar);
        }
