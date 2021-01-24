    public class Program
    {
    public static MyFormsWindow MainWindow { get; private set; }
    [STAThread]
    public static void Main(string[] args)
    {
        Gtk.Application.Init();
        Forms.Init();
        var app = new App();
        var window = new MyFormsWindow();
        window.LoadApplication(app);
        window.SetApplicationTitle("MyApp");
        window.Show();
        MainWindow = window;
        Gtk.Application.Run();
    }
    }
