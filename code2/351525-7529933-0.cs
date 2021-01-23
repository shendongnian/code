    public ActionResult GetFile()
    {
        ....
        FileContentResult file = File(cpFile.CPFileContent, 
                                      cpFile.CPFileMimeType, 
                                      cpFile.CPFileName);
        return file;		
    }
