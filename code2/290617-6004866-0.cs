    // Define a test path
    string filePath = @"C:\Test Folder\";
 
    if (IsFolder(filePath)){
        MessageBox.Show("The given path is a folder.");
    }
    else {
        MessageBox.Show("The given path is a file.");
    }
