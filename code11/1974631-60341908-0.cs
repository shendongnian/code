    #region SevenZipExtractor events
    private void SevenZip_Processing(object sender, ProgressEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("SevenZip_Processing -- " + e.PercentDone + "%");
    
        m_progress.UpdateProcessingStatus(e.PercentDone);
    }
    
    private void SevenZipExtractor_FileExtractionFinished(object sender, FileInfoEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("SevenZipExtractor_FileExtractionFinished -- " + e.PercentDone + "% Filename:" + e.FileInfo.FileName);
    }
    
    private void SevenZipExtractor_FileExtractionStarted(object sender, FileInfoEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("SevenZipExtractor_FileExtractionStarted -- " + e.PercentDone + "% Filename:" + e.FileInfo.FileName);
    }
    #endregion
    
    private void DecompressThread(string archiveFilePath)
    {
        byte[] fileInBytes = File.ReadAllBytes(archiveFilePath);
        using (MemoryStream inStream = new MemoryStream(fileInBytes))
        {
            using (SevenZipExtractor extractor = new SevenZipExtractor(inStream))
            {
                extractor.Extracting += SevenZip_Processing;
                extractor.FileExtractionStarted += SevenZipExtractor_FileExtractionStarted;
                extractor.FileExtractionFinished += SevenZipExtractor_FileExtractionFinished;
                extractor.ExtractArchive("C:\Sandbox\Z-Test");
                extractor.Extracting -= SevenZip_Processing;
                extractor.FileExtractionStarted -= SevenZipExtractor_FileExtractionStarted;
                extractor.FileExtractionFinished -= SevenZipExtractor_FileExtractionFinished;
            }
        }
    }
