    public MainForm()
    {
      InitializeComponent();
      Version version = Assembly.GetExecutingAssembly().GetName().Version;
      Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title
    }
