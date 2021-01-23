    using System.Collections.Generic;
    
    List<int> aTypes = new List<int>();
    List<int> aValues = new List<int>();
    
    string sInput = "1234,5678\n9876,4321\n";
    // Split by linebreak.
    string[] aLinebreaks = sInput.Split('\n');
    foreach(string sNumericString in aLineBreaks)
    {
      // Split by comma.
      string[] aNumbers = sNumericString.Split(',');
      aTypes.Add(Convert.ToInt32(aNumbers[0]);
      aValues.Add(Convert.ToInt32(aNumbers[1]);
    }
    
    ...
    
    aTypes.ToArray();
    aValues.ToArray();
