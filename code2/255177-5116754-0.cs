    using System.IO
    
    // turn file into IEnumerable (streaming works better for larger files)
    IEnumerable<Tuple<int, int, int>> GetTypedEnumerator(string FilePath){
      var File = File.OpenText(FilePath);
      while(!File.EndOfStream) 
          yield return new Tuple<int, int, int>(
              Int.Parse(File[1]), 
              Int.Parse(File[2], 
              Int.Parse(File[3])
          );
       File.Close();
    }
    
    // this lines would return the sum and avg for each line
    var tot = GetTypeEnumerator(@"C:\file.csv").Select(l=>l.Item1 + l.Item2 + l.Item3);
    var avg = GetTypeEnumerator(@"C:\file.csv").Select(l=> (l.Item1 + l.Item2 + l.Item3) / 3);
 
