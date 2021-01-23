    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Spire.Doc;
    
    namespace Xml2Pdf
    {
      class Program
      {
        static void Main(string[] args)
        {
          Document doc = new Document();
          doc.LoadFromFile("sample.xml", FileFormat.Xml);
          doc.SaveToFile("test.doc", FileFormat.Doc);
        }
      }
    }
        
         
