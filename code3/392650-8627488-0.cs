    foreach (string line in assigment_lines)
    {
      if (!string.IsNullOrEmpty(line)) {  
          chars.AddRange(line.Split('=')); // Object reference not set to an instance of object.
      }
    }
    string[] strArray = chars.ToArray();
