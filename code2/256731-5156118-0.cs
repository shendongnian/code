    public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : Control
    {
       if (control.InvokeRequired)
       {
          control.Invoke(action, control);
       }
       else
       {
          action(control);
       }
    }
