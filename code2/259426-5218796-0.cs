    Task<byte[]> getData = new Task<byte[]>(() => GetFileData());
    Task<double[]> analyzeData = getData.ContinueWith(x => Analyze(x.Result));
    Task<string> reportData = analyzeData.ContinueWith(y => Summarize(y.Result));
    getData.Start();
    System.IO.File.WriteAllText(@"C:\reportFolder\report.txt", reportData.Result);
    
