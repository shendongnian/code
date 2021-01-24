    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication142
    {
        class Program
        {
            const string XML_FILENAME = @"c:\temp\test.xml";
            const string CSV_FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args) 
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("E1AFKOL SEGMENT", typeof(int));
                dt.Columns.Add("E1AFKOL MATNR", typeof(long));
                dt.Columns.Add("E1AFFLL SEGMENT", typeof(int));
                dt.Columns.Add("APLZL", typeof(string));
                dt.Columns.Add("E1AFVOL SEGMENT", typeof(int));
                dt.Columns.Add("VORNR", typeof(string));
                dt.Columns.Add("E1RESBL SEGMENT", typeof(int));
                dt.Columns.Add("AUSCH", typeof(decimal));
                dt.Columns.Add("BDART", typeof(string));
                dt.Columns.Add("BDMNG", typeof(decimal));
                dt.Columns.Add("BDTER", typeof(long));
                dt.Columns.Add("E1RESBL MATNR", typeof(string));
                dt.Columns.Add("MEINS", typeof(string));
                dt.Columns.Add("VMENG", typeof(decimal));
                dt.Columns.Add("WERKS", typeof(int));
                XDocument doc = XDocument.Load(XML_FILENAME);
                foreach (XElement E1AFKOL in doc.Descendants("E1AFKOL"))
                {
                    int E1AFKOL_SEGMENT = (int)E1AFKOL.Attribute("SEGMENT");
                    long E1AFKOL_MATNR = (long)E1AFKOL.Element("MATNR");
                    foreach (XElement E1AFFLL in E1AFKOL.Elements("E1AFFLL"))
                    {
                        int E1AFFLL_SEGMENT = (int)E1AFFLL.Attribute("SEGMENT");
                        string APLZL = (string)E1AFFLL.Element("APLZL");
                        foreach (XElement E1AFVOL in E1AFFLL.Elements("E1AFVOL"))
                        {
                            int E1AFVOL_SEGMENT = (int)E1AFVOL.Attribute("SEGMENT");
                            string VORNR = (string)E1AFVOL.Element("VORNR");
                            foreach (XElement E1RESBL in E1AFVOL.Elements("E1RESBL"))
                            {
                                int E1RESBL_SEGMENT = (int)E1RESBL.Attribute("SEGMENT");
                                decimal? AUSCH = (decimal?)E1RESBL.Element("AUSCH");
                                string BDART = (string)E1RESBL.Element("BDART");
                                decimal? BDMNG = (decimal?)E1RESBL.Element("BDMNG");
                                long? BDTER = (long?)E1RESBL.Element("BDTER");
                                string E1RESBL_MATNR = (string)E1RESBL.Element("MATNR");
                                string MEINS = (string)E1RESBL.Element("MEINS");
                                decimal? VMENG = (decimal?)E1RESBL.Element("VMENG");
                                int? WERKS = (int?)E1RESBL.Element("WERKS");
                                dt.Rows.Add(new object[] {
                                    E1AFKOL_SEGMENT,
                                    E1AFKOL_MATNR,
                                    E1AFFLL_SEGMENT,
                                    APLZL,
                                    E1AFVOL_SEGMENT,
                                    VORNR,
                                    E1RESBL_SEGMENT,
                                    AUSCH,
                                    BDART,
                                    BDMNG,
                                    BDTER,
                                    E1RESBL_MATNR,
                                    MEINS,
                                    VMENG,
                                    WERKS 
                                });
                            }
                        }
                    }
                }
                StreamWriter writer = new StreamWriter(CSV_FILENAME);
                string header = string.Join(",", dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName));
                writer.WriteLine(header);
                foreach (DataRow row in dt.AsEnumerable())
                {
                    string rowStr = string.Join(",", row.ItemArray.Select(x => x.ToString()));
                    writer.WriteLine(rowStr);
                }
                writer.Flush();
                writer.Close();
            }
        }
      
     
    }
