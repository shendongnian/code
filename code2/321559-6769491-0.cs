    var parts = new Dictionary<long,string>();
    using (System.IO.StreamReader sr = new System.IO.StreamReader(myfile))
    {
       var sb = new System.Text.StringBuilder();
       long currentPosition = 0;
       long wordPosition = 0;
       bool wordStarted = false;
       int nextCharNum = sr.Read();
       while (nextCharNum >= 0)
       {
          char nextChar = (char)nextCharNum;
          switch(nextChar)
          {
             case ' ':
             case '\r':
             case '\n':
                if (wordStarted)
                {
                   parts[wordPosition] = sb.ToString();
                   sb.Clear();
                   wordStarted = false;
                }
                break;
             default:
                sb.Append(nextChar);
                if (!wordStarted)
                {
                   wordPosition = currentPosition;
                   wordStarted = true;
                }
                break;
          }
          currentPosition += sr.CurrentEncoding.GetByteCount(nextChar.ToString());
          nextCharNum = sr.Read();
       }
       if (wordStarted)
          parts[wordPosition] = sb.ToString();
    }
    foreach (var de in parts)
    {
       Console.WriteLine("{0} {1}", de.Key, de.Value);
    }
