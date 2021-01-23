    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    
    namespace ConsoleApplication1 {
        using System;
        using System.Linq;
        using System.Xml;
        using System.Xml.Linq;
    
        class Program {
            static void Main(string[] args) {
                XDocument xdoc = XDocument.Load(".\\App.xml");
                var result = from e in xdoc.Element("ADSL_CHECKER").Element("MAX").Elements()
                             where e.Name == "MINRANGE"
                             select e;
                Console.WriteLine(result.First().Value);
                Console.ReadKey(true);
            }
        }
    }
