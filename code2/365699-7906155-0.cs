    using System.Xml.Xsl;
    
    namespace XmlTransform
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Load the style sheet.
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(@"C:\style.xsl");
    
                // Execute the transform and output the results to a file.
                xslt.Transform(@"C:\input.xml", @"C:\result.html");
                Console.WriteLine("Result saved to C:\result.html");
                Console.ReadLine();
            }
        }
    }
