    public static class ControlExtensions
    {
      public static void RunInGUIThread<TControl>(this TControl control, Action<TControl> action)
        where TControl: Control
      {
        if (control.InvokeRequired)
          control.Invoke(action, control);
        else
          action(control);
      }
    }
