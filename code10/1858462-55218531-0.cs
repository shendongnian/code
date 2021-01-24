    private void SaveFile_FileOk(object sender, CancelEventArgs e)
    {
       string name = SaveFile.FileName;
       string[] savearray = new string[] { "some test:" }
       File.WriteAllLines(name, savearray);
       //this is just an example, your excel file goes here.
    }
