    using System.Linq;
    public void Execute()
    {
         var files = new string[] { "file1.dat", "file2.dat" };
         var results = GetLines();
         foreach (var file in files.Zip(results, (f, r) => new Tuple<string, IEnumerable<string>>(f, r)))
         {
             File.AppendAllLines(file.Item1, file.Item2);
         }
    }
