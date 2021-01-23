    class InMemoryDb
    {
        SomeBackingStore _store;
    
        void Init(IInitialiser initialiser)
        {
            _store = initialiser.Initialise();
        }
    }
