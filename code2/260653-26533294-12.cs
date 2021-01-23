    // On your page with SaveButton you could do the following trick 
    // (in my case save button is added in DataFormWebPart's XSL markup):
     
    SPContext itemContext;
    DataFormWebPart dataForm; // from designer's code behind
     
    void Page_Init(object sender, EventArgs e)
    {
        // NOTE: by some reason ItemContexts of controls in DFWP are differ,
        // so only SaveButton's OnSaveHandler is invoked
        itemContext = dataForm.Controls.FindControlRecursive<SaveButton>().ItemContext;
    }
     
    void Page_Load(object sender, EventArgs e)
    {
        if (itemContext.FormContext.FormMode == SPControlMode.New ||
            itemContext.FormContext.FormMode == SPControlMode.Edit)
        {
            itemContext.FormContext.OnSaveHandler += OnSaveHandler;
        }
    }
     
    void OnSaveHandler(object sender, EventArgs eventArgs)
    {
        // TODO: Add your code before saving the item
        SaveButton.SaveItem(saveButton.ItemContext, false, string.Empty);
        // TODO: Add your code after saving the item
    }
