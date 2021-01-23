    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace TestConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xmlSerialzer = new XmlSerializer(typeof(Doc));
                var doc = xmlSerialzer.Deserialize(
                    new StreamReader(@"..\..\XmlFile1.xml")) as Doc;
                if(doc == null) return;
                doc.PrintDocItems();
                Console.WriteLine();
    
                //Add a couple new items
                doc.AddDocItem(new DocItem { Text = "E" });
                doc.AddDocItem(new DocItem { Text = "F" });
                doc.PrintDocItems();
            }
        }
    
        public static class DocExtensions
        {
            public static void AddDocItem(this Doc doc, DocItem item)
            {
                var items = doc.Items;
                Array.Resize(ref items, items.Length + 1);
                items[items.Length - 1] = item;
                doc.Items = items;
            }
    
            public static void PrintDocItems(this Doc doc)
            {
                foreach (var item in doc.Items)
                    Console.WriteLine(item.Text);
            }
        }
    }
