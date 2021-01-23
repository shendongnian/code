    public partial class App : Application {
        [STAThread]
        public static int Main() {
            App app = new App();
            app.InitializeComponent();
            var i = app.Run();
            return i;
        }
        public App() : base() { }
        protected override void OnExit(ExitEventArgs e) {
            e.ApplicationExitCode = 110;
            base.OnExit(e);
        }
    }
