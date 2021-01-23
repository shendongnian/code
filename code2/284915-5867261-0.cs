    class abstract StringBuilder
    {
      public virtual string GetDelimiter();
      public string BuildString(string inputString)
      {
         // Your Code goes here...
         GetDelimiter(); // Code to introduce the delimiter
         // Some more of your code
      }
    }
    
    class ExcelStringBuilder : StringBuilder
    {
     public override string GetDelimiter()
     {
       return "\t";
     }
    }
    
    class CsvStringBuilder : StringBuilder
    {
     public override string GetDelimiter()
     {
       return ",";
     }
    }
