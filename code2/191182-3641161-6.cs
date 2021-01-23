    static void InvokeControlUpdate(Control control, MethodInvoker del) {
      MethodInvoker wrapper = () => {
        if ( !control.IsDisposed ) {
          del();
        }
      };
      try {
        control.Invoke(wrapper,null);
      } catch ( ObjectDisposedException ) {
        // Ignore.  Control is disposed cannot update the UI.
      }
    }
