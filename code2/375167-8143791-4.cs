    void Print(TextWriter writer) 
    {
    }
    void PrintToFile(string filePath) 
    {
         using(var textWriter = new StreamWriter(filePath))
         {
             Print(writer);
         }
    }
