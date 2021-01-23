    int GetFileContentNumber(string filename)
    {
      using(var reader=new StreamReader(filename)
      {
        char[] chars=new char[6];
        reader.Read(buf, 0, 6);
        return int.Parse(new String(chars));
        
      }
    }
    
    IEnumerable<string> files = System.IO.Directory.GetFiles(textBox1.Text)
        .Select(filename=>new KeyValuePair<string,int>(filename, GetFileContentNumber(filename)))
        .OrderBy(pair=>pair.Value)
        .Select(pair=>pair.Key);
