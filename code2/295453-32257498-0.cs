        public void IgnoreError(System.Action action)
        {
            try
            {
                action.Invoke();
            }
            catch
            {
            }
        }
        public void SomeMethod()
        {
            IgnoreError(() => { system "pause"; });
        }
