            using System;
            using System.IO;
            using System.Text;
            using HtmlAgilityPack;
            namespace ConsoleApplication4
            {
                class Program
                {
                    private const string html = 
            @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
            <div class='linkProduct' id='link' anattribute='abc'/>
             <bookstore>
             <book>
               <title lang=""eng"">Harry Potter</title>
               <price>29.99</price>
             </book>
             <book>
               <title lang=""eng"">Learning XML</title>
               <price>39.95</price>
             </book>
             </bookstore>
            ";
                    static void Main(string[] args)
                    {
                        HtmlDocument doc = new HtmlDocument();
                        byte[] byteArray = Encoding.ASCII.GetBytes(html); MemoryStream stream = new MemoryStream(byteArray);
                        var ts = new MemoryStream(byteArray);
                        doc.Load(ts);
                        var root = doc.DocumentNode;
                        var tag = root.SelectSingleNode("/div");
                        var attrib = tag.Attributes["anattribute"];
                        Console.WriteLine(attrib.Value);
                    }
                }
            }
