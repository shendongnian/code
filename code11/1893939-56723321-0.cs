    using System;
    using System.Xml;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("test.xml");
                XmlNodeList fooNodes1 = xmlDoc.SelectNodes("/foos/foo/bar/bazs/*"); // starts an absolute path that selects from the root
                                                                                // foos element.
                Console.WriteLine($"Method 1 returned {fooNodes1.Count} nodes."); 
                XmlNodeList fooNodes2 = xmlDoc.SelectNodes("/foos/foo");    // "/foo" the document element(<foo>) of this document.
            
                foreach (XmlNode fooNode in fooNodes2)
                { 
                    var bazNodes2 = fooNode.SelectNodes("./bar/bazs/baz");  // "." indicates the current node.
                    var bazNodes3 = fooNode.SelectNodes("bar/bazs/baz"); // selects all baz elements that are children of an bazs element, 
                                                                     // which is itself a child of the root bar element.
                    var bazNodes4 = fooNode.SelectNodes("bar/bazs/*");   // "*" selects any element in the path.
                    var bazNodes5 = fooNode.SelectNodes("bar/*/baz");   
                    var bazNodes6 = fooNode.SelectNodes("//bazs/*");     // selects any elements that are children of an bazs element, 
                                                                     // regardless of where bazs appear in the current context.
                    var bazNodes7 = fooNode.SelectNodes("bar//baz");     // selects all the baz elements that are under an bar element, 
                                                                     // regardless of where they appear in the current context.
                    var bazNodes8 = fooNode.SelectNodes("//bazs/baz");   // selects all the bazs elements that are children of an baz element, 
                                                                     // regardless of where they appear in the document.
                    var bazNodes9 = fooNode.SelectNodes("//baz");        // starts a relative path that selects baz element anywhere.
            
                    XmlNode barNode = fooNode.SelectSingleNode("bar");
                    var bazNodes10 = barNode.SelectNodes("bazs/*");     // selects all nodes which are contained by a root bazs element.
                
                    Console.WriteLine($"Method 2 returned {bazNodes2.Count} nodes.");
                    Console.WriteLine($"Method 3 returned {bazNodes3.Count} nodes.");
                    Console.WriteLine($"Method 4 returned {bazNodes4.Count} nodes.");
                    Console.WriteLine($"Method 5 returned {bazNodes5.Count} nodes.");
                    Console.WriteLine($"Method 6 returned {bazNodes6.Count} nodes.");
                    Console.WriteLine($"Method 7 returned {bazNodes7.Count} nodes.");
                    Console.WriteLine($"Method 8 returned {bazNodes8.Count} nodes.");
                    Console.WriteLine($"Method 9 returned {bazNodes9.Count} nodes.");
                    Console.WriteLine($"Method 10 returned {bazNodes10.Count} nodes.");
                }
            
                Console.Read();
            }
        }
    }
