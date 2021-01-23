    class GenericClass<TClass>
    {
        public void DoSomething(Object input)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (!input.GetType().IsAssignableFrom(typeof(TClass)))
                throw new ArgumentException("Input type must be assignable from " + typeof(TClass).ToString(), "input");
            // ...
        }
    }
