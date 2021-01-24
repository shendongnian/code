    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Giorno", typeof(int));
                dt.Columns.Add("Mese", typeof(int));
                dt.Columns.Add("Anno", typeof(int));
                dt.Columns.Add("Via", typeof(string));
                dt.Columns.Add("Comune", typeof(string));
                dt.Columns.Add("Provincia", typeof(string));
                dt.Columns.Add("Cap", typeof(int));
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> datiAnagraficis = doc.Descendants("DatiAnagrafici").ToList();
                foreach(XElement datiAnagrafici in datiAnagraficis)
                {
                    int giorno = (int)datiAnagrafici.Descendants("Giorno").FirstOrDefault();
                    int mese = (int)datiAnagrafici.Descendants("Mese").FirstOrDefault();
                    int anno = (int)datiAnagrafici.Descendants("Anno").FirstOrDefault();
                    string via = (string)datiAnagrafici.Descendants("Via").FirstOrDefault();
                    string comune = (string)datiAnagrafici.Descendants("Comune").FirstOrDefault();
                    string provincia = (string)datiAnagrafici.Descendants("Provincia").FirstOrDefault();
                    int cap = (int)datiAnagrafici.Descendants("Cap").FirstOrDefault();
                    dt.Rows.Add(new object[] { giorno, mese, anno, via, comune, provincia, cap });
                }
            }
        }
     }
