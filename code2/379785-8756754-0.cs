    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Collections.ObjectModel;
    using System.Reactive.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static XDocument doc; 
    
            static void Main(string[] args)
            {
    
                doc = XDocument.Parse("<books><book>Gone with the wind</book></books>");
                doc.Changed += Doc_Changed;
                doc.Changing += Doc_Changing;
    
                PrintResults();
    
                XElement newElement = new XElement("book", "Treasure Island");
    
                doc.Elements().First().Add(newElement);
                newElement.Remove(); //remove this noe from parent
                Console.ReadLine();
            }
    
            static void Doc_Changing(object sender, XObjectChangeEventArgs e)
            {
                PrintChangeResults(e);
            }
    
            static void Doc_Changed(object sender, XObjectChangeEventArgs e)
            {
                PrintChangeResults(e);
            }
    
            public static void PrintChangeResults(XObjectChangeEventArgs e)
            {
                Console.WriteLine(string.Format("Change was {0}, Document now has {1} elements", 
                    e.ObjectChange, doc.Elements().First().Elements().Count()));
            }
    
            public static void PrintResults()
            {
                Console.WriteLine(string.Format("Document now has {0} elements", 
                    doc.Elements().First().Elements().Count()));
            }
        }
    }
