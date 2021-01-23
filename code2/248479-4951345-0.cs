        Dispatcher.BeginInvoke(new Action(delegate {               
           HwndSource hwndSource = PresentationSource.FromVisual(this) as System.Windows.Interop.HwndSource;
                if (null == hwndSource) {
                    throw new InvalidOperationException("No HWND");
                }
                HwndTarget hwndTarget = hwndSource.CompositionTarget;
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
       
      }),System.Windows.Threading.DispatcherPriority.ContextIdle, null);
