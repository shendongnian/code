    class MyType { 
      struct ParsedData { 
        // Data from the file
      }
      
      public MyType(string filePath) : this(Parse(filePath)) { 
        // The Parse method will throw here if the data is invalid
      }
    
      private MyType(ParsedData data) {
        // Operate on the valid data.  This doesn't throw since the errors
        // have been rooted out already in TryParseFile
      }
    
      public static bool TryParse(string filePath, out MyType obj) {
        ParsedData data;
        if (!TryParseFile(filePath, out data)) {
          obj = null;
          return false;
        }
    
        obj = new MyType(data);
        return true;
      }
    
      private static ParsedData Parse(string filePath) {
        ParsedData data;
        if (!TryParseFile(filePath, out data)) {
          throw new Exception(...);
        }
        return data;
      }
      private static bool TryParseFile(string filePath, out ParsedData data) {
        // Parse the file and implement error detection logic here
      }
    }
