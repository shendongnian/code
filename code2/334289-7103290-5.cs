    string root = ConfigurationSettings.AppSettings["SaveImagefolderPath"];
    string extension = ".txt";
    bool newlyFolderCreated = false;
    if (!System.IO.Directory.Exists(root))
    {
        System.IO.Directory.CreateDirectory(root);
        newlyFolderCreated = true;
    }
    doc.Save(GetUniqueFileName(root, extension), 
        Leadtools.Forms.DocumentWriters.DocumentFormat.Text, null);
    
    if (newlyFolderCreated)
    { 
        MessageBox.Show("folder created and image output saved");
    }
    else
    {
        MessageBox.Show("ImageFolder is available  images are  Saved into folder Now");
    }
