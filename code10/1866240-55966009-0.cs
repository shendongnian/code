    public void LoadCategories()
        {
            CategoriesCombo.Items.Clear();
            Outlook.Application application = new Outlook.Application();
            Outlook.NameSpace ns = application.GetNamespace("MAPI");
            Outlook.MAPIFolder selectedFolder = application.ActiveExplorer().CurrentFolder;
            if (selectedFolder is Outlook.MAPIFolder)
            {
                Outlook.Folder folder = selectedFolder as Outlook.Folder;
                Outlook.Store store = folder.Store;
                Outlook.Categories categories = store.Categories;
            }
        }
