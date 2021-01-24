    public class ScanData
    {
       public DateTime Time { get; set; }
       public int Scan { get; set; }
       public decimal?[] MassResults  { get; set; }
    
       public static ScanData FromString(string data)
       {
          var split = data.Split('\t');
    
          decimal? Local(string value)
          {
             return decimal.TryParse(value, NumberStyles.Float, null, out var output) ? output : (decimal?)null;
          }
    
          var scanData = new ScanData()
                         {
                            Time = DateTime.ParseExact(split[0].Trim('"'), "M/d/yyyy h:m:s tt", null),
                            Scan = int.Parse(split[1]),
                            MassResults = split.Skip(2).Select(Local).ToArray()
                         };
    
          return scanData;
       }
    
    }
