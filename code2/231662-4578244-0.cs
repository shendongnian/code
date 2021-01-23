    Application: MetroTwit.exe
    Framework Version: v4.0.30319
    Description: The process was terminated due to an unhandled exception.
    Exception Info: System.InvalidOperationException
    Stack:
       at System.Windows.Application.GetResourcePackage(System.Uri)
       at System.Windows.Application.LoadComponent(System.Object, System.Uri)
       at MetroTwit.View.ErrorView.InitializeComponent()
       at MetroTwit.View.ErrorView..ctor(System.String)
       at MetroTwit.App.Application_DispatcherUnhandledException(System.Object,     System.Windows.Threading.DispatcherUnhandledExceptionEventArgs)
       at System.Windows.Threading.Dispatcher.CatchException(System.Exception)
       at MS.Internal.Threading.ExceptionFilterHelper.TryCatchWhen(System.Object,         
        System.Delegate, System.Object, Int32, System.Delegate)
       at System.Windows.Threading.Dispatcher.WrappedInvoke(System.Delegate, System.Object, 
        Int32, System.Delegate)
       at System.Windows.Threading.Dispatcher.InvokeImpl(
        System.Windows.Threading.DispatcherPriority, System.TimeSpan, System.Delegate, 
        System.Object, Int32)
       at MS.Win32.HwndSubclass.SubclassWndProc(IntPtr, Int32, IntPtr, IntPtr)
       at MS.Win32.UnsafeNativeMethods.DispatchMessage(System.Windows.Interop.MSG ByRef)
       at System.Windows.Threading.Dispatcher.PushFrameImpl(
        System.Windows.Threading.DispatcherFrame)
       at System.Windows.Application.RunInternal(System.Windows.Window)
       at System.Windows.Application.Run()
       at MetroTwit.App.Main()
