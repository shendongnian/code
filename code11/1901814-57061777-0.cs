    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement Impuestos = doc.Descendants().Where(x => x.Name.LocalName == "Impuestos").FirstOrDefault();
                XElement Traslado = Impuestos.Descendants().Where(x => x.Name.LocalName == "Traslado").FirstOrDefault();
                string Impuesto =  (string)Traslado.Attribute("Impuesto");
                decimal Importe = (decimal)Traslado.Attribute("Importe");
            }
        }
    }
