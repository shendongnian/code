    Dictionary<string, int> extensions = new Dictionary<string, int>();
    
    Action<string> CalcFilesCount = null;
    
    CalcFilesCount = f =>
         {
             var files = Directory.GetFiles(f).GroupBy(p => Path.GetExtension(p));
    
             foreach (var ex in files)
             {
                 if (extensions.Keys.Contains(ex.Key))
                     extensions[ex.Key] += ex.Count();
                 else
                     extensions[ex.Key] = ex.Count();
             }
    
             foreach (var p2 in Directory.GetDirectories(f))
                 CalcFilesCount(p2);
         };
    
    CalcFilesCount(path);
    
    foreach (var   item in extensions)
        Console.WriteLine(item.Key + " :" + item.Value);
