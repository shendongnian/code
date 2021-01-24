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
            static void Main(string[] args)
            {
                string xml = "<foo:document xmlns=\"http://www.example.com/xmlns\" xmlns:foo=\"http://www.example.com/xmlns/foo-version1\">" +
                             "   <foo:bar foo:baz=\"true\" />" +
                             "</foo:document>";
                XDocument doc = XDocument.Parse(xml);
            }
        }
    }
