    public class BinaryStorage
    {
      // add methods CopyTo, Zip, and Unzip
     
      public void writeToFile(List<dynamic> data, string fname)
      {
        string jtext = JsonConvert.SerializeObject(data, Formatting.None);
        File.WriteAllBytes(fname, Zip(jtext));
      }
    
      public List<dynamic> readFromFile(string fname)
      {
        var bin = File.ReadAllBytes(fname);
        var res = JsonConvert.DeserializeObject<List<dynamic>>(Unzip(bin));
        return res;
      }
    }
