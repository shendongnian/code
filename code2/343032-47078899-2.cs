     IDisposable disposable;
     public void SomeMethod(Observable observeMe) {
       disposable = observeMe.ObservableProperty.WeakSubscribe(this, (wo, n) => wo.Log(n));
     }
      public void Log(int n) {
        System.Diagnostics.Debug.WriteLine("log "+n);
      }
