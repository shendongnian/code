    public void CreateFileListList()
    {
         for (int i = 0; i <100; i++)
         {
             FileListClass flo = new FileListClass
             flo.sourceType = SourceTypes.WAN;
             flo.deletesource = true;
             [...]
    
             myList.add(flo);
         }
    }
                 
    
