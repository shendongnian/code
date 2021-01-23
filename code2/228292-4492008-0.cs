    private void SetProjectFolder(string sessionid)
    {
        //IoC container gives the root directory to begin search.
        string[] supportDirs = Directory.GetDirectories(ApplicationContainer.SupportDirectory);
        // search for product subfolder
        foreach (string directory in supportDirs)
        {
            foreach (string folder in Directory.GetDirectories(directory))
            {
                foreach (string productSubFolder in Directory.GetDirectories(folder))
                {
                    if (productSubFolder.Contains(sessionid))
                    {
                        // product sub-folder found, set it and exit
                        _productName = Directory.GetParent(productSubFolder).Parent.Name;
                        return;
                    }
                }
            }
        }
        // product sub-folder not found
        !!! handle error path
    }
