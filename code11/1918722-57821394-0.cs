     public bool IsMainThread => Build.VERSION.SdkInt >= BuildVersionCodes.M
    ? Looper.MainLooper.IsCurrentThread
    : Looper.MyLooper() == Looper.MainLooper;
    public void RunOnMainThread(Action action)
    {
      if (IsMainThread) action();
      else RunOnUiThread(action);
    } 
