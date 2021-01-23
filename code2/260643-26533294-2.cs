    private SaveButton saveButton;
    private DataFormWebPart dataForm; // from designer's code behind
    protected void OnInit(object sender, EventArgs e)
    {
        // NOTE: by some reason ItemContexts of controls in DFWP are differ,
        // so only SaveButton's OnSaveHandler is invoked
        saveButton = dataForm.Controls
            .FindControlRecursive<SaveButton>();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (saveButton.ItemContext.FormContext.FormMode == SPControlMode.New)
            saveButton.ItemContext.FormContext.OnSaveHandler += OnSaveHandler;
    }
    
    private void OnSaveHandler(object sender, EventArgs eventArgs)
    {
        SaveButton.SaveItem(saveButton.ItemContext, false, string.Empty);
    }
