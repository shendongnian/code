    static void Main(string[] args)
    {
        HashSet<string> FileData = new HashSet<string>();
        using (var md5 = MD5.Create())
        {
             using (var stream = File.OpenRead("C:\\FolderTest\\Document.txt"))
             {
                  var hash = md5.ComputeHash(stream);
                  var data = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                  FileData.Add(data);
             }
             using (var stream = File.OpenRead("C:\\FolderTest\\Document.txt"))
             {
                  var hash = md5.ComputeHash(stream);
                  var data = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                  FileData.Add(data);
             }
             using (var stream = File.OpenRead("C:\\FolderTest\\Document2.txt"))
             {
                  var hash = md5.ComputeHash(stream);
                  var data = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                  FileData.Add(data);
             }
        }
        foreach (var file in FileData)
        {
             Console.WriteLine(file);
        } 
        Console.ReadKey();
    }
