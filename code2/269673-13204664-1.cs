    using System.Linq;
    using FileZip = System.Tuple<
        System.String,
        System.Collections.Generic.IEnumerable<
            System.String>>;
    public void Execute()
    {
         var files = new string[] { "file1.dat", "file2.dat" };
         var results = GetLines();
         foreach (var file in files.Zip(results, (f, r) => new FileZip(f, r)))
         {
             File.AppendAllLines(file.Item1, file.Item2);
         }
    }
