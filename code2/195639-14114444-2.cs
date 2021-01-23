        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Xml;
        namespace ewp_tool
        {
            class Program
            {
                static void Main(string[] args)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(args[0]);
                    XmlNodeList list = doc.SelectNodes("/project/configuration[name='Debug']/settings[name='ILINK']/data/option[name='IlinkConfigDefines']/state");
                    foreach(XmlElement x in list) {
                        x.InnerText = "MAIN_APP=1";
                    }
                    using (XmlTextWriter xtw = new XmlTextWriter(args[1], Encoding.UTF8))
                    {
                        //xtw.Formatting = Formatting.Indented; // leave this out, it breaks EWP!
                        doc.WriteContentTo(xtw);
                    }
                }
            }
        }
