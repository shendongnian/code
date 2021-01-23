		using System;
		using System.Linq;
		using System.Xml.Linq;
        class MyClass
        {
            static void Main(string[] args)
            {
                XElement xmlcode =
                XElement.Parse("<reply success=\"true\">More nodes go  </reply>");
                var successAttributes =
					from attribute in xmlcode.Attributes()
					where attribute.Name.LocalName=="success" 
					select attribute ;
                if(successAttributes.Count()>0)
                foreach (var sa in successAttributes)
                {
                    Console.WriteLine(sa.Value);           
                }
                Console.ReadLine();
            }
        }
