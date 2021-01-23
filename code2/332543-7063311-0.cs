    // read file content into a string
    String fileContent = System.IO.File.ReadAllText(@"c:\file.dat");
    // compare TextBox content with file content
    if (fileContent.Equals(myTextBox.Text))
    {
        // do something
    }
    else
    {
        MessageBox.Show("Error!");
    }
