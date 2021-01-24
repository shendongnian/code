    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string PATH = @"c:\temp\";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Codes", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("Weight", typeof(int));
                dt.Rows.Add(new object[] { "1", "620111000", 1.00, 20 });
                dt.Rows.Add(new object[] { "2", "610433000", 4.00, 30 });
                dt.Rows.Add(new object[] { "3", "620111005", 7.00, 50 });
                dt.Rows.Add(new object[] { "4", "620111006", 6.00, 60 });
                dt.Rows.Add(new object[] { "5", "620111006", 5.00, 70 });
                string xml = "<xml><MyCollections></MyCollections></xml>";
               
                var groups = dt.AsEnumerable().OrderBy(x => x.Field<string>("Codes")).GroupBy(x => x.Field<string>("Codes")).ToList();
                
                XDocument doc = XDocument.Parse(xml);
                XElement myCollections = doc.Descendants("MyCollections").FirstOrDefault();
                int sequence = 0;
                int file_count = 1;
                XElement myCollection = null;
                XElement myItems = null;
                string firstGroupName = "";
                string code = "";
                foreach (var group in groups)
                {
                    code = group.Key;
                    //only add here if there is not 99 items in file
                    //other wise it will be added later
                    if (sequence < 99)
                    {
                        myCollection = new XElement("MyCollection", new XElement("Code", code));
                        myCollections.Add(myCollection);
                        myItems = new XElement("MyItems");
                        myCollection.Add(myItems);
                        firstGroupName = group.Key;
                    }
                    foreach (DataRow row in group)
                    {
                        sequence++;
                        if (sequence > 99)
                        {
                            if (firstGroupName == code)
                            {
                                doc.Save(PATH + code + "_" + file_count.ToString() + ".xml");
                            }
                            else
                            {
                                doc.Save(PATH + firstGroupName + "_" + code + "_" + file_count.ToString() + ".xml");
                            }
                            file_count++;
                            sequence = 1;
                            doc = XDocument.Parse(xml);
                            myCollections = doc.Descendants("MyCollections").FirstOrDefault();
                            myCollection = new XElement("MyCollection", new XElement("Code", code));
                            myCollections.Add(myCollection);
                            myItems = new XElement("MyItems");
                            myCollection.Add(myItems);
                        }
                        XElement myItem = new XElement("MyItem", new object[] {
                            new XElement("Sequence", sequence),
                            new XElement("Price", row.Field<decimal>("Price")),
                            new XElement("Weight", row.Field<int>("Weight"))
                        });
                        myItems.Add(myItem);
                    }
                }
                if (myItems.Elements("MyItem") != null)
                {
                    if (firstGroupName == code)
                    {
                        doc.Save(PATH + code + "_" + file_count.ToString() + ".xml");
                    }
                    else
                    {
                        doc.Save(PATH + firstGroupName + "_" + code + "_" + file_count.ToString() + ".xml");
                    }
                }
            }
        }
    }
