    public class ZoneTrigger : CriticalFinalizerObject
    {
      private ZoneTriggerCallbackProc _zoneTriggerCallback;
      private IntPtr _zoneTriggerCallbackCookie;
      public ZoneTrigger()
      {
        _zoneTriggerCallback = ZoneTriggerCallback;
        // Why not just do it here?
        _zoneTriggerCallbackCookie = NativeMethods.ZT_SetCallbackProc(_zoneTriggerCallback);
        if (_zoneTriggerCallbackCookie == IntPtr.Zero)
           throw new Exception("Failed to set callback");
      }
       private unsafe int ZoneTriggerCallback(int MessageType, ref ZT_TRIG_STRUCT trigInfo)
       {
         // ...
       }
      ~ZoneTrigger()
      {
         var oldCookie = Interlocked.Exchange(ref _zoneTriggerCallback, IntPtr.Zero);
         if (oldCookie != IntPtr.Zero)
           ZT_ClearCallbackProc(oldCookie);
      }
    }
