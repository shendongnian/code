    private SaveButton saveButton;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
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
