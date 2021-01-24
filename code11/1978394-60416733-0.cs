    public MainWindow()
    {
      InitializeComponent();
      Top = 0;
      Left = 0;
      Height = SystemParameters.PrimaryScreenHeight;
      Width = SystemParameters.PrimaryScreenWidth;
      Forms.Init();
      LoadApplication(new SharedForms.App());
    }
