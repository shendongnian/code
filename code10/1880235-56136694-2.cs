    public SOMEDialogue (List<ISelectedVal> inputValues)
    {
        InitializeComponent();
        DataContext = new SomeDialogViewModel(inputValues);
    }
