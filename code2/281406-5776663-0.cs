    public static void SafeThreadAction<T>(this T control, Action<T> call)
        where T : System.Windows.Threading.DispatcherObject
    {
      if (!control.Dispatcher.CheckAccess())
        control.Dispatcher.Invoke(call, control);
      else
        call(control);
    }
