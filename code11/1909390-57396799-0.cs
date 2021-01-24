csharp
public MainPage()
{
    this.InitializeComponent();
    Window.Current.Dispatcher.AcceleratorKeyActivated += AccelertorKeyActivedHandle;
}
private async void AccelertorKeyActivedHandle(CoreDispatcher sender, AcceleratorKeyEventArgs args)
{
    if (args.EventType.ToString().Contains("Down"))
    {
        var ctrl = Window.Current.CoreWindow.GetKeyState(Windows.System.VirtualKey.Control);
        if (ctrl.HasFlag(CoreVirtualKeyStates.Down))
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Number1)
            {
                // add the content in textbox
            }
        }
    }
}
This registration method is global registration, you can run related functions when the trigger condition is met.
Best regards.
