    foreach (var line in File.ReadLines(myFilePath)) {
      if (line.Equals("code 65") || line.Equals("code 78")) 
        continue;
    
      // some logic to format lines into columns....
      // ....Append(string.Format("{0, -15}{1, -15}{2, -15}", lineValue1, lineValue2, lineValue3));
    }
