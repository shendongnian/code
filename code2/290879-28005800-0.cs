    try
    {
       var type = typeof(ImageAnimator);
       var info = type.GetField("animationThread", BindingFlags.NonPublic | BindingFlags.Static);
       if (info != null)
       {
           var value = info.GetValue(null);
           var thread = value as Thread;
           if (thread != null && thread.IsAlive)
           {
                thread.Abort();
           }
        }
    }
    catch{}
