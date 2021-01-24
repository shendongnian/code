      private static void Search(string[] input)
    {
        string datafile = @"C:\Users\User\Documents\text.txt";
        string inputfile = @"C:\Users\User\Documents\input.txt;
        string outputfile = @"C: \Users\User\Documents\output.txt;
        string[] parameters = System.IO.File.ReadAllLines(inputfile);
        string[] data = System.IO.File.ReadAllLines(datafile);
        var index = new Dictionary<string, Thing>();
        for (int i = 0; i <= data.Length; i += 2)
        {
            string currentline = data[i];
            string[] splitline = currentline.Split(' ');
            Thing t = new Thing() {
              DataPointNumber = splitline[0].Trim('>'),
              DataPointName = splitline[1],
              Information = data[i+1],
              LineNumber = i
            }
            index[t.DataPointNumber] = t;
        }
        foreach(var p in parameters)
        {
            if (index.ContainsKey(p))
              Console.WriteLine($"Found {p}: {index[p]}"); //ToString will be called
            else 
              Console.WriteLine($"File doesn't contain {p}");
        }
    }
    public class Thing{
      public string DataPointNumber{get;set;}
      public string DataPointName{get;set;}
      public string Information{get;set;}
      public int LineNumber{get;set;} 
      public overrride string ToString(){
        return $"Line:{LineNumber}-{DataPointNumber} with info {Information}";
      }
    }
