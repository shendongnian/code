    public FileDownloadMessage GetExportedFile()
    {
    	FileDownloadMessage f = new FileDownloadMessage();
    	f.FileByteStream = new MemoryStream();
    
    	if ( ProgressMonitor.Status == ProcessStatus.CompletedReadyForExport )
    	{
    	    f.FileByteStream = ProgressMonitor.ExportedFileData;
    
    	    ProgressMonitor.Status = ProcessStatus.Ready;
    	}
    	else
    	{
    		f.FileByteStream = null;
    	}
    
    	return f;
    }
