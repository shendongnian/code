    //Add in MyClass
    public void UploadFile(string path)
    {
        this.FileManager.UploadFile(path);
    }
    
    //Called like this
    myClass.UploadFile(@"c:\path\to\other\file.txt");
