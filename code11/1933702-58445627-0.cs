    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement product in doc.Descendants("Product"))
                {
                    string productName = (string)product.Element("ProductName");
                    string info = (string)product.Element("info");
                    foreach (XElement option in product.Descendants("Option"))
                    {
                        string variation = (string)option.Element("variationID");
                        string barcode = (string)option.Element("Barcode");
                        Console.WriteLine("Product Name : '{0}', Info : '{1}', variation : '{2}', barcode : '{3}'",
                            productName.Trim(), info.Trim(), variation.Trim(), barcode.Trim());
                    }
                }
                Console.ReadLine();
            }
        }
    }
