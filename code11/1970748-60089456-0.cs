        public IDisposable SubscribeToChannels()
        {
            return Observable
                   .CombineLatest(_Sessions.Select(s => s.State))
                   .Subscribe(states =>
                   {
                       if (states.All(s => s == SessionState.NotConnected))
                            Foo();
                   });
        }
