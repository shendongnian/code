    foreach (String str in File.ReadLines("c:\test.txt"))
    {
          String[] strCols = str.Split(Convert.ToChar(" "));
          for (int i =0; i < strCols.length; i++)
          {
               Row[i] = strCols[i].Substring(2); //This will start reading from the third character
          }
    }
