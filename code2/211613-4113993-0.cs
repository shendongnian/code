    public static IEnumerable<string> GetMismatches(IList<string> fileNames, IList<string> processedFileNames, StringComparer comparer)
        {
            var filesIndex = 0;
            var procFilesIndex = 0;
    
            while (filesIndex < fileNames.Count)
            {
                if (procFilesIndex >= processedFileNames.Count)
                {
                    yield return files[filesIndex++];
                }
                else
                {
                    var rc = comparer.Compare(fileNames[filesIndex], processedFileNames[procFilesIndex]);
                    if (rc != 0)
                    {
                        if (rc < 0)
                        {
                            yield return files[filesIndex++];
                        }
                        else
                        {
                            procFilesIndex++;
                        }
                    }
                    else
                    {
                        filesIndex++;
                        procFilesIndex++;
                    }
                }
            }
    
            yield break;
        }
