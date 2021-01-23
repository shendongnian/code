        class SomeClass
        {   
            // Define an event including signature
            public ThreadSafeEventDispatcher<Func<SomeClass, bool>> OnSomeEvent = 
                    new ThreadSafeEventDispatcher<Func<SomeClass, bool>>();
                              
            void SomeMethod() 
            {
                OnSomeEvent += HandleEvent; // subscribe
                OnSomeEvent.Raise(e => e(this)); // raise
            }
            public bool HandleEvent(SomeClass someClass) 
            { 
                return true; 
            }           
        }
