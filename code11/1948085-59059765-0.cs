    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var path = (@"PATH");
                XElement target = XElement.Load(path);
                XElement source = XElement.Load(path);
                var mergefields = GetMergeAttr(target);
    
                foreach (var sourceElement in source.Elements())
                {
                    var targetElements = from mergefield in mergefields
                                         select target.Elements().SingleOrDefault(t => 
                                             {
                                                 if (t.Attribute(mergefield) == null || sourceElement.Attribute(mergefield) == null)
                                                 {
                                                     return false;
                                                 }
    
                                                 return String.Equals(
                                                 t.Attribute(mergefield).Value,
                                                 sourceElement.Attribute(mergefield).Value,
                                                 StringComparison.InvariantCultureIgnoreCase);
                                             }
                                         );
                    foreach (var element in targetElements)
                    {
                        Console.WriteLine(element);
                    }
                }
    
                Console.ReadLine();
            }
    
            private static string[] GetMergeAttr(XElement element)
            {
                string mergefield = (string)element.Attribute("mergefield");
                return mergefield.Split(',');
            }
        }
    }
