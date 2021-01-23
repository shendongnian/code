    for (int i = 0; i < fileList.Count; i++)
    {
       string[] lineItems = (string[])fileList[i];
       if (!Regex.IsMatch (lineItems[0], "^\d+$")) // numbers
          throw new ArgumentException ("invalid id at row " + i);
       if (!Regex.IsMatch (lineItems[1], "^[a-zA-Z]+$")) // surnames - letters-only
          throw new ArgumentException ("invalid surname at row " + i);
       if (!Regex.IsMatch (lineItems[2], "^[a-zA-Z]+$")) // names - letters-only
          throw new ArgumentException ("invalid name at row " + i);
    }
