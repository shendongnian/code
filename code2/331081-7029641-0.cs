    public static class XmlPrinter {
       private const Int32 SpacesPerIndent = 3;
    
       public static void Print(XDocument xDocument) {
          if (xDocument == null) {
             Console.WriteLine("No XML Document Provided");
             return;
          }
    
          PrintElementRecursive(xDocument.Root);
       }
    
       private static void PrintElementRecursive(XElement element, Int32 indentationLevel = 0) {
          if(element == null) return;
    
          PrintIndentation(indentationLevel);
          PrintElement(element);
          PrintNewline();
    
          foreach (var xAttribute in element.Attributes()) {
             PrintIndentation(indentationLevel + 1);
             PrintAttribute(xAttribute);
             PrintNewline();
          }
    
          foreach (var xElement in element.Elements()) {
             PrintElementRecursive(xElement, indentationLevel+1);
          }
       }
    
       private static void PrintAttribute(XAttribute xAttribute) {
          if (xAttribute == null) return;
    
          Console.Write("[{0}] = \"{1}\"", xAttribute.Name, xAttribute.Value);
       }
    
       private static void PrintElement(XElement element) {
          if (element == null) return;
             
          Console.Write("{0}", element.Name);
             
          if(!String.IsNullOrWhiteSpace(element.Value))
             Console.Write(" : {0}", element.Value);
       }
    
       private static void PrintIndentation(Int32 level) {
          Console.Write(new String(' ', level * SpacesPerIndent));
       }
    
       private static void PrintNewline() {
          Console.Write(Environment.NewLine);
       }
    }
