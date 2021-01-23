    public System.IO.MemoryStream GetExportedFile()
    {
    	GetExportedFileRequest inValue = new GetExportedFileRequest();
    	FileDownloadMessage retVal = ((IDailyBillingParser)(this)).GetExportedFile( inValue );
    	return retVal.FileByteStream;
    }
