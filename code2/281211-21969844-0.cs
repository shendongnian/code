    public static class ControlExtensions
    {
      public static void EnsureInvokeAsync(this Control control, Action action)
      {
         if (control.InvokeRequired) control.BeginInvoke(action);
         else action();
      }
    }
    
    class MyControl : UserControl
    {
        void M(string s)
        {
           // the lambda will capture the string in a closure
           // the compiler does all the hard work for you
           this.EnsureInvokeAsync(() => _button.Text = s);
        }
    }
