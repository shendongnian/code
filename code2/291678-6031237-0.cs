    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    
    namespace ConsoleApplication1 {
        using System;
        using System.Xml;
    
        class Program {
            static void Main(string[] args) {
                XmlDocument xdoc = new XmlDocument();
                try {
                    xdoc.Load(".\\App.xml");
                }
                catch (System.Xml.XmlException ex) {
                    // handle
                }
                XmlNode node = xdoc.SelectSingleNode("ADSL_CHECKER//MAX//MINRANGE");
                Console.WriteLine(node.InnerText);
                Console.ReadKey(true);
            }
        }
    }
