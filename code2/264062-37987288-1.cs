    using Microsoft.WindowsAPICodePack.Shell;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
    string filePath = @"C:\temp\example.docx";
    var file = ShellFile.FromFilePath(filePath);
    
    // Read and Write:
    string[] oldAuthors = file.Properties.System.Author.Value;
    string oldTitle = file.Properties.System.Title.Value;
    file.Properties.System.Author.Value = new string[] { "Author #1", "Author #2" };
    file.Properties.System.Title.Value = "Example Title";
    
    // Alternate way to Write:
    
    ShellPropertyWriter propertyWriter =  file.Properties.GetPropertyWriter();
    propertyWriter.WriteProperty(SystemProperties.System.Author, new string[] { "Author" });
    propertyWriter.Close();
    
