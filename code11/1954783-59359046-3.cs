    [Export(typeof(IMainWindowView))]
    public partial class MainWindowView : MetroWindow, IMainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            MainWindowSettingsProvider settingsProvider = MainWindowSettingsProvider.Instance;
            this.SetPlacement(settingsProvider.MainWindowSettings.WindowPlacementInfo);
        }
    }
    
