        public ABC() : this
        (
            (IMemoryCache) Activator.CreateInstance
            (
                Assembly.GetExecutingAssembly().GetTypes().First
                (
                    t => typeof(IMemoryCache).IsAssignableFrom(t) && !t.IsInterface
                )
            )
        )
        {
        }
