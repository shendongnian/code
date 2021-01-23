    string wholeFile = "";
    using(StreamReader str = new StreamReader(path))
    {
       wholeFile = str.ReadToEnd();
    }
    string[] lines = wholeFile.Split('\n').Replace("\r", "");
    for(int i = 0; i < lines.Length; i++)
    {
       //parse the line
       string line = lines[i];
       if(line.Trim().StartsWith("ipaddress"))
       {
           string value = line.Trim().Replace("ipaddress", "");
           //Do something with the value here...
       }
    }
