[TestMethod]
public void TestWpfApp()
{
    Thread thread = new Thread(() =>
    {
        var application = new App();
        Application.ResourceAssembly = System.Reflection.Assembly.GetExecutingAssembly();
        application.InitializeComponent();
        application.Dispatcher.InvokeAsync(() =>
        {
            _TestApplication(application);
        }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        application.Run();
    });
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    thread.Join();
}
private static async void _TestApplication(Application application)
{
    Window window = application.MainWindow;
    ViewModel viewModel = (ViewModel)window.DataContext;
    await Task.Delay(TimeSpan.FromSeconds(5));
    viewModel.Text = "Hello World!";
    await Task.Delay(TimeSpan.FromSeconds(5));
    window.Close();
}
The basic structure is to set up a thread suitable for running the WPF UI (it has to be an STA thread, and you shouldn't be messing with the unit test's thread, so creating a new thread for this purpose is required), and then in that thread, do the usual WPF setup plus queue via `InvokeAsync()` to the dispatcher a call to the main testing method, to have it start executing once the WPF code has started running.
Naturally, this example assumes a `ViewModel` class with a `Text` property, and the main window's `DataContext` property set to an instance of this `ViewModel`. In my sample program, I just bound the `Text` property to a `TextBlock.Text` property. Obviously, you could do whatever you want with your view model.
Note that I had to explicitly set `Application.ResourceAssembly`. In Visual Studio Community 2017, which is what I'm using at the moment, the unit test framework runs the text in a context where `Assembly.GetEntryAssembly()` returns `null`, which breaks WPF's resource loading. Setting it explicitly fixes that (I'm using `Assembly.GetExecutingAssembly()`, because I put the unit test code in the same assembly with my sample WPF program&hellip;obviously, if you keep them in different assemblies, you'd have to find the right assembly some other way).
In my testing, using `System.Windows.Threading.DispatcherPriority.ApplicationIdle` in the call to `Dispatch.InvokeAsync()` wasn't strictly required. I found the `MainWindow` and `DataContext` properties initialized fine. But I prefer to explicitly wait for `ApplicationIdle`, just to make sure those have been fully initialized and that the WPF program itself is ready to start accepting whatever input you have in mind for your tests.
