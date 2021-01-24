    string line = sr.ReadLine();
    int tot = -1;
    if(line.ToLower().StartsWith("total registered participants:"){
      line = line.ToLower().Replace("total registered participants:", "").Trim();
      int.TryParse(line, out tot);
    }
    else if(...)
