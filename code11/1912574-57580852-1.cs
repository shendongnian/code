    using System;
    using System.Xml.Linq;
    
    namespace XML_57556340
    {
        class Program
        {
            static void Main(string[] args)
            {
                DoIt("M:\\StackOverflowQuestionsAndAnswers\\XML_57556340\\Data.xml");
                Console.ReadLine();
            }
    
            private static void DoIt(string v)
            {
                XDocument xdoc =  XDocument.Load(v, LoadOptions.None);
                foreach (XElement item in xdoc.Root.Elements("ArrayOfString"))
                {
                    string theline = string.Empty;
                    foreach (XElement ele in item.Elements())
                    {
                        theline += ele.Value;
                    }
                    Console.WriteLine(theline);
                }
            }
        }
    }
