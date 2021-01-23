    private static bool isDirectoryCreated;
    //...
    var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
    Parallel.ForEach(dtResult.AsEnumerable(), options, dr =>
    {
        string fileName, extractQuery, newDownLoadPath;
        lock (foreachObject)
        {
            fileName = extractorConfig.EncodeFileName(dr);
            extractQuery = extractorConfig.GetExtractQuery(dr);
               
            if (string.IsNullOrEmpty(extractQuery))
                throw new Exception("Extract Query not found. Please check the configuration");
            newDownLoadPath = CommonUtil.GetFormalizedDataPath(sDownLoadPath, uKey.CobDate);
            if (!isDirectoryCreated)
            {
                if (!Directory.Exists(newDownLoadPath))
                    Directory.CreateDirectory(newDownLoadPath);
                isDirectoryCreated = true;
            }
        }
        string downLoadFileFullName = Path.Combine(newDownLoadPath, fileName);
               
        Interlocked.Increment(ref index);
        ExtractorClass util = new ExtractorClass(SourceDbConnStr);
        util.LoadToFile(extractQuery, downLoadFileFullName);
                
        Interlocked.Increment(ref uiTimerIndex);
    });
