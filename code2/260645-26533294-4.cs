    SaveButton saveButton;
    DataFormWebPart dataForm; // from designer's code behind
    void Page_Init(object sender, EventArgs e)
    {
        // NOTE: by some reason ItemContexts of controls in DFWP are differ,
        // so only SaveButton's OnSaveHandler is invoked
        saveButton = dataForm.Controls.FindControlRecursive<SaveButton>();
    }
    
    void Page_Load(object sender, EventArgs e)
    {
        if (saveButton.ItemContext.FormContext.FormMode == SPControlMode.New ||
            saveButton.ItemContext.FormContext.FormMode == SPControlMode.Edit)
        {
            saveButton.ItemContext.FormContext.OnSaveHandler += OnSaveHandler;
        }
    }
    
    void OnSaveHandler(object sender, EventArgs eventArgs)
    {
        // TODO: Add your code before saving the item
        SaveButton.SaveItem(saveButton.ItemContext, false, string.Empty);
        // TODO: Add your code after saving the item
    }
