    public YourWindowConstructor()
    {
        InitializeComponent();
        DataObject.AddCopyingHandler(flowDocumentReader1, CustomCopyCommand);
    }
    private void CustomCopyCommand(object sender, DataObjectEventArgs e)
    {
        e.CancelCommand(); //disable the default copy behavior that executes after this function returns
        // custom clipboard code here ...
        Clipboard.SetData("Text", "new text");
    }
