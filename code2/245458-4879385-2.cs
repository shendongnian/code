    var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
    Parallel.ForEach(dtResult.AsEnumerable(), options, dr =>
    {
        string extractQuery, newDownLoadPath;
        lock (foreachObject)
        {
            extractQuery = extractorConfig.GetExtractQuery(dr);
               
            if (string.IsNullOrEmpty(extractQuery))
                throw new Exception("Extract Query not found. Please check the configuration");
            newDownLoadPath = CommonUtil.GetFormalizedDataPath(sDownLoadPath, uKey.CobDate);
        }
        if (!Directory.Exists(newDownLoadPath))
            Directory.CreateDirectory(newDownLoadPath);
        string downLoadFileFullName = Path.Combine(newDownLoadPath, fileName);
               
        Interlocked.Increment(ref index);
        ExtractorClass util = new ExtractorClass(SourceDbConnStr);
        util.LoadToFile(extractQuery, downLoadFileFullName);
                
        Interlocked.Increment(ref uiTimerIndex);
    });
