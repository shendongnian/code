    SPFileCollection collFiles = oFolder.Files;
    
            long lngTotalFileSize = 0;
    
            for (int intIndex = 0; intIndex < collFiles.Count; intIndex++)
            {
                lngTotalFileSize += collFiles[intIndex].Length;
            }
