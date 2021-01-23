    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    
    namespace ConsoleApplication1 {
        using System;
        using System.Xml;
        using System.Xml.Linq;
    
        class Program {
            static void Main(string[] args) {
                XDocument xdoc = XDocument.Load(".\\App.xml");
                XElement element = xdoc.Element("ADSL_CHECKER").Element("MAX").Element("MINRANGE");
                Console.WriteLine(element.Value);
                Console.ReadKey(true);
            }
        }
    }
