        public event Action SomethingHappened;
        void OnSomethingHappened()
        {
            if (SomethingHappened!= null) SomethingHappened();
        }
        public void DoSomething()
        {
            // Actual logic here, then notify listeners
            OnSomethingHappened();
        }
