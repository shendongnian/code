    // Assuming you have a string named fileName that holds the name of the file
    if (!System.IO.Directory.Exists("D:\\SaveImageOutPutFolder"))
    {
        System.IO.Directory.CreateDirectory("D:\\SaveImageOutPutFolder");
        doc.Save(ConfigurationSettings.AppSettings["SaveImagefolderPath"] + "\\" + fileName, Leadtools.Forms.DocumentWriters.DocumentFormat.Text, null);
            MessageBox.Show("folder created and image output saved");
    }
    else
    {
        doc.Save(ConfigurationSettings.AppSettings["SaveImagefolderPath"] + "\\" + fileNAme, Leadtools.Forms.DocumentWriters.DocumentFormat.Text, null);
        MessageBox.Show("ImageFolder is available  images are  Saved into folder Now");
    }
