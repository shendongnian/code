while(bool found = false)
{
    string[] files = System.IO.Directory.GetFiles(path, "*.csv", System.IO.SearchOption.TopDirectoryOnly);
    if (files.Length > 0)
    {
        //.csv file in a known directory exists
        found = true;
    }
    
    Thread.Sleep(100);
}
