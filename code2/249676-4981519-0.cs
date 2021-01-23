    string[] files = System.IO.Directory.GetFiles("c:\\temp", "*.*", IO.SearchOption.TopDirectoryOnly);
    
    List<string> del = (
       from string s in files
       where ! (s.EndsWith(".zip"))
       select s).ToList();
    
    Parallel.ForEach(del, (string s) => { IO.File.Delete(s); });
