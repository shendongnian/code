      private void YourFileRoutine(string sourceDirectoryPath, string consolidatedDirectoryPath)
        {
            var excelFiles = new DirectoryInfo(sourceDirectoryPath).GetFiles().Where(x => x.Extension == ".xlsx");
            //Copy all Excel Files to consolidated Directory
            foreach (var excelFile in excelFiles)
            {
                FileInfo copiedFile = excelFile.CopyTo(String.Concat(consolidatedDirectoryPath, excelFile.Name)); // Make sure consolidatedDirectoryPath as a "\" maybe use Path.Combine()?
                // ConvertToCSV( Do your CSV conversion here, the Path will be = Path.GetFullPath(copiedFile);
            }
            // Merge CSV's
            var csvFiles = new DirectoryInfo(consolidatedDirectoryPath).GetFiles().Where(x => x.Extension == ".csv");
            // SomeMergeMethod that iterates through this FileInfo collection?
        }
