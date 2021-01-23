    public IEnumerable<FileInfo> addCriteria(IEnumerable<FileInfo> FileList,
                                             List<String> searchCriteria)
    { 
       var newFileList = FileList;
       foreach(String criteria in searchCriteria)
       {
           newFileList = newFileList.Where(f => f.FileName.Contains(criteria).AsQueryable();
       }
       return newFileList.AsEnumerable();
    }
