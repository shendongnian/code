    public static void CreateCrashReport(Exception ex, string extra = null)
    {
        var crashInfo = new Dictionary<object, object>
        {
            [NSError.LocalizedDescriptionKey] = ex.Message + (!string.IsNullOrEmpty(extra) ? extra : ""),
            ["StackTrace"] = ex.StackTrace,
        };
    
        var error = new NSError(new NSString(ex.Message),
            -1001,
            NSDictionary.FromObjectsAndKeys(crashInfo.Values.ToArray(), crashInfo.Keys.ToArray(),
            crashInfo.Keys.Count));
    
        Crashlytics.SharedInstance.RecordError(error);
    }   
