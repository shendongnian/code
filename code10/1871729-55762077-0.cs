    using System;
    using System.Xml;
    var xml = new XmlDocument();
    xml.LoadXml("<Invoice> <Note>Fatura Tipi:MM Alınan Mlz.İade<Note> </Invoice>");
    XmlText node = xml.SelectSingleNode("//Note[contains(text(), 'Fatura Tipi:']/text())");
    Console.WriteLine(node.Value.Split(':')[1]);
