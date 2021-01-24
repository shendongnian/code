    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Record> records = new List<Record>();
                foreach (XElement record in doc.Descendants("record"))
                {
                    Record newRecord = new Record();
                    records.Add(newRecord);
                    foreach (XElement field in record.Elements("field"))
                    {
                        string name = (string)field.Attribute("name");
                        switch (name)
                        {
                            case "Country or Area":
                                newRecord.country_area_key = (string)field.Attribute("key");
                                newRecord.country_area_name = (string)field;
                                break;
                            case "Item":
                                newRecord.item_key = (string)field;
                                break;
                            case "Year":
                                newRecord.year = (int)field;
                                break;
                            case "Value":
                                newRecord.value = (decimal)field;
                                break;
                        }
                    }
                }
                               
            }
        }
        public class Record
        {
            public string country_area_key { get;set;}
            public string country_area_name { get;set;}
            public string item_key { get;set;}
            public int year { get;set;}
            public decimal value { get;set;}
        } 
     
    }
