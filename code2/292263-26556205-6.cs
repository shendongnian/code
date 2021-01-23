    class Program
    {
      static void Main(string[] args)
      {
        var _source = new FileInfo(@"C:\Temp\bigfile.rar");
        var _destination = new FileInfo(@"C:\Temp\bigfile2.rar");
  
        if (_destination.Exists) _destination.Delete();
    
        _source.CopyTo(_destination, x => Console.WriteLine($"{x}% Complete"));
        Console.WriteLine("File Copied.");
      }
    }
