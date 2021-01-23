    StringBuilder sb = new StringBuilder();
    using(var sr = new System.IO.StreamReader('path/to/your/file.txt'))
    {
      while(true)
      {
         string line = sr.ReadLine();
         // if this is the final line, break out of the while look
         if(line == null)
            break;
         // append this line to the string builder
         sb.Append(line);
      }
      sr.Close();
    }
    
    // the sb instance hold all the text in the file, less the \r and \n characters
    string textWithoutEndOfLineCharacters = sb.ToString();
