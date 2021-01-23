        string foo;
        public Listener(Input input, string f)
        {
            input.SomethingChanged += OnSomethingChanged;
            // Because this is thrown...
            throw new InvalidOperationException();
            // ... this never happens
            foo = f;
        }
