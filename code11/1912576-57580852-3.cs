    using System;
    using System.Xml;
    
    namespace XML_57556340
    {
        class Program
        {
            static void Main(string[] args)
            {
                doitagain("M:\\StackOverflowQuestionsAndAnswers\\XML_57556340\\Data.xml");
                Console.ReadLine();
            }
    
    
            private static void doitagain(string v)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(v);
                foreach (XmlNode item in xdoc.GetElementsByTagName("ArrayOfString"))
                {
                    foreach (XmlElement ele in item.ChildNodes)
                    {
                        Console.Write(ele.InnerText);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
