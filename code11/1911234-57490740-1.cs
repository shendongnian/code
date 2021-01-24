    Regex regex = new Regex(@"^p\d+");
    foreach (string line in textfile)
    {    
       if (!regex.IsMatch(line)){ // get only the lines without starting by pxxx
          newFile.Append(temp + "\r\n");
       }
       newFile.Append(line + "\r\n");
    }
