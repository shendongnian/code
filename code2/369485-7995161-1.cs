    public FilePathResult GetFile()
    {
        string name = System.IO.Path.GetTempPath()+Guid.NewGuid().ToString()+".xls";
        // do the work
        xlWorksheet.Save(name);
        return File(name, "Application/x-msexcel");
    }
