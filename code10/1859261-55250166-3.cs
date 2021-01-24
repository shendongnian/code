    public class LoadManager
    {
        public CheckNetwork check;
        public Loading loading;
        public Loading2 loading2;
        public SplashScrean splashScreen;
    
        // suprise: a not well documented fact 
        // you can simply make the Start method an IEnumerator (Coroutine)
        // so you can directly wait for anything you want
        private void IEnumerator Start()
        {
            // Next suprise: You can simply yield other IEnumerators
            // that makes them execute and at the same time waits until they are finished
            // so all methods that you want to wait for from here
            // should be IEnumerators
    
            // as said this is only an example 
            // you could directly within that single
            // Coroutine do your complete download and check routine together
            yield return check.CheckPermissions();
            if(!check.isReachable)
            {
                yield break;
            }
    
            // same for chekcing the version
            yield return check.CheckVersion();
    
            if(!check.isUpToDate)
            {
                // do something for update
                yield break;
            }
    
            // is up to date so start and wait for loading
            yield return loading.LoadAsyncOperation();
    
            // and so on
        }
    }
