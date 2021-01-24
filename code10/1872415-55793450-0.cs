    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace mNs = root.GetNamespaceOfPrefix("m");
                List<XElement> xMeterReadings = doc.Descendants(mNs + "MeterReading").ToList();
                List<MeterReadings> meterReadings = new List<MeterReadings>();
                foreach(XElement xMeterReading in xMeterReadings)
                {
                    MeterReadings newMeterReading = new MeterReadings();
                    meterReadings.Add(newMeterReading);
                    XElement valuesInterval = xMeterReading.Element(mNs + "valuesInterval");
                    newMeterReading.start = (DateTime)valuesInterval.Element(mNs + "start");
                    newMeterReading.end = (DateTime)valuesInterval.Element(mNs + "end");
                    XElement meter = xMeterReading.Element(mNs + "Meter");
                    newMeterReading.name = (string)meter.Descendants(mNs + "name").FirstOrDefault();
                    newMeterReading.nameType  = (string)meter.Descendants(mNs + "name").LastOrDefault();
                    newMeterReading.mRid = (string)meter.Element(mNs + "mRID");
                    List<XElement> xReadings = xMeterReading.Elements(mNs + "Readings").ToList();
                    foreach (XElement xReading in xReadings)
                    {
                        if (newMeterReading.meterReadings == null) newMeterReading.meterReadings = new List<MeterReading>();
                        MeterReading meterReading = new MeterReading();
                        newMeterReading.meterReadings.Add(meterReading);
                        meterReading.readingType = (string)xReading.Element(mNs + "ReadingType").Attribute("ref");
                        meterReading.start = (DateTime)valuesInterval.Descendants(mNs + "start").FirstOrDefault();
                        meterReading.end  = (DateTime)valuesInterval.Descendants(mNs + "end").FirstOrDefault();
                        meterReading.value = (decimal)xReading.Element(mNs + "value");
                        meterReading.timestamp = (DateTime)xReading.Element(mNs + "timeStamp");
                    }
                }
            }
        }
        public class MeterReadings
        {
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public string name { get; set; }
            public string nameType { get; set; }
            public string mRid { get; set; }
            public List<MeterReading> meterReadings { get; set; }
        }
        public class MeterReading
        {
            public string readingType { get; set; }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public DateTime timestamp { get; set; }
            public decimal value { get; set; }
        }
     
    }
