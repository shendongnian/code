    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    class MyClass
    {
        static void Main(string[] args)
        {        
        
          XElement xmlcode = 
          XElement.Parse("<reply success=\"true\">More nodes go  </reply>");
          var  firstAttribute =
                                (from attribute in xmlcode.Attributes()
                                 select attribute).First();
         
            Console.WriteLine(firstAttribute);
         
             Console.ReadLine();
      }
    }
