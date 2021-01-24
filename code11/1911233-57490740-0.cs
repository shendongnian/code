    Regex regex = new Regex(@"p\d+");
    foreach (string line in textfile)
    {    
       if (!regex.IsMatch(line)){
          newFile.Append(temp + "\r\n");
       }
       newFile.Append(line + "\r\n");
    }
