    public string MyPath1;
    public string MyPath2;
    ...
    public void ReadConfig(string sConfigFile)
    {
      MyPath1 = MyPath2 = "";  // Clear the external values (in case the file does not set every parameter).
      using (StreamReader sr = new StreamReader(sConfigFile))  // Open the file for reading (and auto-close).
      {
        while (!sr.EndOfStream)
        {
          string sLine = sr.ReadLine().Trim();  // Read the next line. Trim leading and trailing whitespace.
          // Treat lines with NO "=" as comments (ignore; no syntax checking).
          // Treat lines with "=" as the first character as comments too.
          // Treat lines with "=" as the 2nd character or after as parameter lines.
          // Side-benefit: Values containing "=" are processed correctly.
          int i = sLine.IndexOf("=");  // Find the first "=" in the line.
          if (i <= 0) // IF the first "=" in the line is the first character (or not present),
            continue;  // the line is not a parameter line. Ignore it. (Iterate the while.)
          string sParameter = sLine.Remove(i).TrimEnd();  // All before the "=" is the parameter name. Trim whitespace.
          string sValue = sLine.Substring(i + 1).TrimStart();  // All after the "=" is the value. Trim whitespace.
          // Extra characters before a parameter name are usually intended to comment it out. Here, we keep them (with or without whitespace between). That makes an unrecognized parameter name, which is ignored (acts as a comment, as intended).
          // Extra characters after a value are usually intended as comments. Here, we trim them only if whitespace separates. (Parsing contiguous comments is too complex: need delimiter(s) and then a way to escape delimiters (when needed) within values.) Side-drawback: Values cannot contain " ".
          i = sValue.IndexOfAny(new char[] {' ', '\t'});  // Find the first " " or tab in the value.
          if (i > 1) // IF the first " " or tab is the second character or after,
            sValue = sValue.Remove(i);  // All before the " " or tab is the parameter. (Discard the rest.)
          // IF a desired parameter is specified, collect it:
          // (Could detect here if any parameter is set more than once.)
          if (sParameter == "MyPathOne")
            MyPath1 = sValue;
          else if (sParameter == "MyPathTwo")
            MyPath2 = sValue;
          // (Could detect here if an invalid parameter name is specified.)
          // (Could exit the loop here if every parameter has been set.)
        } // end while
      // (Could detect here if the config file set neither parameter or only one parameter.)
      } // end using
    }
