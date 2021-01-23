    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace xmlRead
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create("sample.xml");
                XDocument myDoc = XDocument.Load(reader);
    
                //checking if theire a results element ?
                int count = myDoc.Descendants("results").Count();
    
                if (count == 0)
                {
                    //do what your programs does to do
                    //for example reading embed_enabled and put in variable declared before :)
    
                    XElement embededEnabled = (from xml2 in myDoc.Descendants("embed_enabled") select xml2).FirstOrDefault();
                    Console.WriteLine("item to: {0}", embededEnabled);
                }
                Console.ReadLine();
            }
        }
    }
