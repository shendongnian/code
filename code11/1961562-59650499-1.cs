    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.txt";
            const string OUTPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME1 = @"c:\temp\test1.xml";
            static DataTable dt = new DataTable();
            static XDocument doc;
            static void Main(string[] args)
            {
                ReadData(INPUT_FILENAME);
                dt = dt.AsEnumerable()
                    .OrderBy(x => x.Field<string>("scheme-code"))
                    .ThenBy(x => x.Field<string>("emp-code"))
                    .ThenBy(x => x.Field<string>("pin"))
                    .CopyToDataTable();
                CreateXml();
                doc.Save(OUTPUT_FILENAME);
                //add new node
                foreach (XElement employer in doc.Descendants("employer"))
                {
                    XElement t999 = employer.Elements("data").Where(x => (string)x.Element("serial-no") == "T999").FirstOrDefault();
                    int maxSerialNumber = employer.Descendants("serial-no").Where(x => (string)x != "T999").Max(x => (int)x);
                    //copy an existing node as template for new data node.
                    XElement newData = XElement.Parse(employer.Element("data").ToString());
                    if (t999 == null)
                    {
                        newData.Element("serial-no").SetValue("T999");
                        employer.Add(newData);
                    }
                    else
                    {
                        newData.Element("serial-no").SetValue(maxSerialNumber + 1);
                        t999.ReplaceWith(new object[] { newData, t999 });
                    }
                }
                doc.Save(OUTPUT_FILENAME1);
            }
            static void ReadData(string filename)
            {
                int rowNumber = 0;
                string line = "";
                StreamReader reader = new StreamReader(INPUT_FILENAME);
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splitData = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (++rowNumber == 1)
                    {
                        for (int i = 0; i < splitData.Length; i++)
                        {
                            if (i < 3)
                            {
                                dt.Columns.Add(splitData[i], typeof(string));
                            }
                            else
                            {
                                dt.Columns.Add(splitData[i], typeof(decimal));
                            }
                        }
                    }
                    else
                    {
                        DataRow newRow = dt.Rows.Add();
                        for (int i = 0; i < splitData.Length; i++)
                        {
                            if (i < 3)
                            {
                                newRow[i] = splitData[i];
                            }
                            else
                            {
                                newRow[i] = decimal.Parse(splitData[i]);
                            }
                        }
                    }
                }
                reader.Close();
            }
            static void CreateXml()
            {
                string xmlns_rmas = "value here";
                string xmlns_xsi = "value here";
                string xmlns_noNamespaceSchemaLocation = "value here";
                string xmlIdentFormat =
                    "<?xml version='1.0' encoding='UTF-8'?>" +
                    "<return" +
                        " xmlns:rmas=\"{0}\"" +
                        " xmlns:xsi=\"{1}\"" +
                        " xsi:noNamespaceSchemaLocation=\"{2}\">" +
                    "</return>";
                string xmlIdent = string.Format(xmlIdentFormat, xmlns_rmas, xmlns_xsi, xmlns_noNamespaceSchemaLocation);
                doc = XDocument.Parse(xmlIdent);
                XElement _return = doc.Root;
                string returnCode = "";
                string returnDesc = "";
                DateTime date = DateTime.Now;
                string operatorCode = "";
                XElement header = new XElement("header", new object[] {
                    new XElement("return-code", returnCode),
                    new XElement("return-desc", returnDesc),
                    new XElement("as-at-date", date),
                    new XElement("operator-code", operatorCode)
                });
                _return.Add(header);
                XElement body = new XElement("body");
                _return.Add(body);
                foreach (var schemeGroup in dt.AsEnumerable().GroupBy(x => x.Field<string>("scheme-code")))
                {
                    XElement scheme = new XElement("scheme");
                    body.Add(scheme);
                    XElement code = new XElement("code", schemeGroup.Key);
                    scheme.Add(code);
                    foreach (var empCodeGroup in schemeGroup.GroupBy(y => y.Field<string>("emp-code")))
                    {
                        XElement employer = new XElement("employer");
                        scheme.Add(employer);
                        int serialNumber = 0;
                        foreach (var pinGroup in empCodeGroup.GroupBy(y => y.Field<string>("pin")))
                        {
                            if (serialNumber == 0)
                            {
                                XElement emprCode = new XElement("empr-code", empCodeGroup.Key);
                                employer.Add(emprCode);
                            }
                            foreach (DataRow row in pinGroup)
                            {
                                XElement data = new XElement("data");
                                employer.Add(data);
                                if ((empCodeGroup.Count() > 1) && (serialNumber == empCodeGroup.Count() - 1))
                                {
                                    data.Add(new XElement("serial-no", "T999"));
                                }
                                else
                                {
                                    data.Add(new XElement("serial-no", serialNumber));
                                }
                                data.Add(new XElement("pin", pinGroup.Key));
                                data.Add(new XElement("employer-contribution", row.Field<decimal>("empr-contr")));
                                data.Add(new XElement("employee-contribution", row.Field<decimal>("empyee-contr")));
                                data.Add(new XElement("voluntary-contribution", row.Field<decimal>("total-vol-cont")));
                                data.Add(new XElement("total-contribution", row.Field<decimal>("total")));
                                serialNumber++;
                            }
                        }
                    }
                }
            }
        }
    }
