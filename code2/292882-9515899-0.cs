    public partial class Splashscreen:Window
    {
     static Splashscreen splashscreen;
        public Splashscreen()
        {
            InitializeComponent();
        }
        public static void ShowSplashScreen()
        {
            splashscreen = new Splashscreen();
            splashscreen.Show();
        }
        public static Splashscreen SplashScreen { get { return splashscreen; } set { splashscreen = value; } }
