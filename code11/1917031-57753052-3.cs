    [assembly: Dependency(typeof(AndroidStartAndCloseCamera))]
    namespace App18.Droid
    {
      private int sec = 20;
      System.Threading.Timer _dispatcherTimer;
      class AndroidStartAndCloseCamera : IStartAndCloseCamera
        {
          public void Open()
           {
            TimerCallback timerDelegate = new TimerCallback(Tick);
            Intent intent1 = new Intent(MediaStore.IntentActionStillImageCamera);
            MainActivity.Instance.StartActivityForResult(intent1, 0);
            _dispatcherTimer = new System.Threading.Timer(timerDelegate, null, 0, 1000);
            return true;
           }
        
        private void Tick(object state)
        {          
           MainActivity.Instance.RunOnUiThread(() =>
            {
                if (sec > 0)
                {
                    sec--;
                }
                else
                {
                    _dispatcherTimer.Dispose();
                    MainActivity.Instance.FinishActivity(0);
                }
            });
       
        }
       }
    }
