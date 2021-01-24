    using System.IO;
    
    public void Main(string[] args)
    {
      var ac = new FileInfo(@"C:\Test.txt").GetAccessControl();
      // ac has the ACL for the file
    }
