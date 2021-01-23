    static class Program
  
    {
    
    static void Main()
    
    {
       
    string v1 = "1.23.56.1487";
    string v2 = "1.24.55.487";
    var version1 = new Version(v1);
    var version2 = new Version(v2);
     var result = version1.CompareTo(version2);
        if (result > 0)
            Console.WriteLine("version1 is greater");
        else if (result < 0)
            Console.WriteLine("version2 is greater");
        else
            Console.WriteLine("versions are equal");
        return;
    }
}
