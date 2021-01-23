    public string DownloadFile(string trimURL
        , string TrimRecordNumber
        , out byte[] docContents
        , out string returnFiletype
        , out string returnFilename)
    {
        docContents = null;
        //...
            returnFiletype = myRec.Extension;
            returnFilename = myRec.SuggestedFileName;
            docContents = new byte[result.Length]; // Allocate appropriately here...
            Buffer.BlockCopy(result, 0, docContents, 0, result.Length); 
            return ...
