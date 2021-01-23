    class myTypeCollection : List<System.Type>
    {
        override void Add(Type t)
        {
            if (t.GetInterface(typeof(MyCustomInterface)) == null)
                throw new InvalidOperationException("Type does not implement MyCustomInterface");
            base.Add(t);
        }
    }
