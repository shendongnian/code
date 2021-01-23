    try
    {
        // Open the source document.
        wordDocument = wordApplication.Documents.Open(
            ref paramSourceDocPath, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing);
    
        // Export it in the specified format.
        if (wordDocument != null)
            wordDocument.ExportAsFixedFormat(paramExportFilePath,
                paramExportFormat, paramOpenAfterExport, 
                paramExportOptimizeFor, paramExportRange, paramStartPage,
                paramEndPage, paramExportItem, paramIncludeDocProps, 
                paramKeepIRM, paramCreateBookmarks, paramDocStructureTags, 
                paramBitmapMissingFonts, paramUseISO19005_1,
                ref paramMissing);
    }
    catch (Exception ex)
    {
        // Respond to the error
    }
    finally
    {
        // Close and release the Document object.
        if (wordDocument != null)
        {
            wordDocument.Close(ref paramMissing, ref paramMissing,
                ref paramMissing);
            wordDocument = null;
        }
    
        // Quit Word and release the ApplicationClass object.
        if (wordApplication != null)
        {
            wordApplication.Quit(ref paramMissing, ref paramMissing,
                ref paramMissing);
            wordApplication = null;
        }
        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
