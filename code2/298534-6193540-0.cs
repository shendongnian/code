        class Foo
        {
            private Factory factory;
            public Factory CreatingFactory
            {
                get { return factory; }
                set
                {
                    if (factory != null)
                    {
                        throw new InvalidOperationException("the factory can only be set once");
                    }
                    factory = value;
                }
            }
        }
        class Factory
        {
            public T Create<T>()
                where T : Foo, new()
            {
                T t = new T()
                {
                    CreatingFactory = this
                };
                return t;
            }
        }
