        public void StartProcess(Action<string> continueWith)
        {
           string result;
           while (IsRunning)
           {
              // do stuff
              result = "success";
           }
           // all done... call continuation delegate.
           continueWith (result);
        }
