    string root = ConfigurationSettings.AppSettings["SaveImagefolderPath"];
    if (!System.IO.Directory.Exists(root))
    {
        System.IO.Directory.CreateDirectory(root);
        doc.Save(GetUniqueFileName(root), Leadtools.Forms.DocumentWriters.DocumentFormat.Text, null);
        MessageBox.Show("folder created and image output saved");
    }
    else
    {
        doc.Save(GetUniqueFileName(root), Leadtools.Forms.DocumentWriters.DocumentFormat.Text, null);
        MessageBox.Show("ImageFolder is available  images are  Saved into folder Now");
    }
