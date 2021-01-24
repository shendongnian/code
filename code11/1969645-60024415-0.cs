    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string ident = "<?xml version=\"1.0\"?><Document></Document>";
                XDocument doc = XDocument.Parse(ident);
                XElement root = doc.Root;
                XElement header = new XElement("CUSTOMERPAYMENTJOURNALHEADERENTITY", new object[] {
                    new XElement("JOURNALBATCHNUMBER"),
                    new XElement("DESCRIPTION", "Sundry Debtor Receipts"),
                    new XElement("JOURNALNAME", "CUSTPAY")
                });
                root.Add(header);
                int lineNumber = 0;
                string line = "";
                string[] columnNames = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        lineNumber++;
                        string[] splitArray = line.Split(new char[] { ',' }).ToArray();
                        if (lineNumber == 1)
                        {
                            columnNames = splitArray;
                        }
                        else
                        {
                            XElement entity = new XElement("CUSTOMERPAYMENTJOURNALLINEENTITY");
                            header.Add(entity);
                            for (int i = 0; i < columnNames.Length; i++)
                            {
                                XElement newElement = new XElement(columnNames[i].Trim(), splitArray[i].Trim());
                                entity.Add(newElement);
                            }
                        }
                    }
                }
            }
        }
    }
