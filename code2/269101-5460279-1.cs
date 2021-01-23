    public string Parse(string fileName)
     {
         string res = null;
         int errorLine = -1;  
         try
         {
            // foreach line of text to parse -- errorLine  = lineNumber;
            /// parse the file, assign parse result to res
         }  
         catch (Exeption ex)
         {
           MyParsingException myEx= new MyParsingException ("parsing error", ex);
           myEx.Data["fileName"] = fileName;
           myEx.data["lineNumber"] = errorLine ;
           throw myEx;
         }
         return res;
     }
     // then you can have some really useful info:
 
    try
    {
        myParser.Parse(fileName)
    }
    catch(MyParsingException ex)
    {
      // use ex.Data to get the "fileName" and "lineNumber" properties.
    }
