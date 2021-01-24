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
                foreach (XElement xMeterReading in xMeterReadings)
                {
                    MeterReadings newMeterReading = new MeterReadings();
                    meterReadings.Add(newMeterReading);
                    XElement valuesInterval = xMeterReading.Element(mNs + "valuesInterval");
                    newMeterReading.start = (DateTime)valuesInterval.Element(mNs + "start");
                    newMeterReading.end = (DateTime)valuesInterval.Element(mNs + "end");
                    XElement meter = xMeterReading.Element(mNs + "Meter");
                    newMeterReading.name = (string)meter.Descendants(mNs + "name").FirstOrDefault();
                    newMeterReading.nameType = (string)meter.Descendants(mNs + "name").LastOrDefault();
                    newMeterReading.mRid = (string)meter.Element(mNs + "mRID");
                    List<XElement> xReadings = xMeterReading.Elements(mNs + "Readings").ToList();
                    foreach (XElement xReading in xReadings)
                    {
                        string readingType = (string)xReading.Element(mNs + "ReadingType").Attribute("ref");
                        ReadTypeEnum typeEnum = MeterReading.GetType(readingType);
                        if (typeEnum != ReadTypeEnum.NONE)
                        {
                            if (newMeterReading.meterReadings == null) newMeterReading.meterReadings = new List<MeterReading>();
                            MeterReading meterReading = new MeterReading();
                            newMeterReading.meterReadings.Add(meterReading);
                            meterReading.readingType = readingType;
                            meterReading.start = (DateTime)valuesInterval.Descendants(mNs + "start").FirstOrDefault();
                            meterReading.end = (DateTime)valuesInterval.Descendants(mNs + "end").FirstOrDefault();
                            meterReading.value = (decimal)xReading.Element(mNs + "value");
                            meterReading.timestamp = (DateTime)xReading.Element(mNs + "timeStamp");
                        }
                    }
                }
            }
        }
        public enum ReadTypeEnum
        {
            KWH1,
            KVH1,
            MDI1,
            KWH2,
            KVH2,
            MDI2,
            NONE
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
            private ReadTypeEnum _readingType { get; set; }
            public string readingType
            {
                get
                {
                    string readTypeStr = "";
                    switch (_readingType)
                    {
                        case ReadTypeEnum.KVH1:
                            readTypeStr = "13.26.0.1.1.1.12.0.0.0.0.1.0.0.224.3.72.0";
                            break;
                        case ReadTypeEnum.KVH2:
                            readTypeStr = "13.26.0.1.1.1.12.0.0.0.0.2.0.0.224.3.72.0";
                            break;
                        case ReadTypeEnum.KWH1:
                            readTypeStr = "13.26.0.1.1.1.12.0.0.0.0.1.0.0.224.3.73.0";
                            break;
                        case ReadTypeEnum.KWH2:
                            readTypeStr = "13.26.0.1.1.1.12.0.0.0.0.2.0.0.224.3.72.0";
                            break;
                        case ReadTypeEnum.MDI1:
                            readTypeStr = "13.8.0.6.1.1.8.0.0.0.0.1.0.0.224.3.38.0";
                            break;
                        case ReadTypeEnum.MDI2:
                            readTypeStr = "13.8.0.6.1.1.8.0.0.0.0.2.0.0.224.3.38.0";
                            break;
                    }
                    return readTypeStr;
                }
                set { _readingType = GetType(value); }
            }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public DateTime timestamp { get; set; }
            public decimal value { get; set; }
            public static ReadTypeEnum GetType(string value)
            {
                ReadTypeEnum readTypeEnum;
                switch (value)
                {
                    case "13.26.0.1.1.1.12.0.0.0.0.1.0.0.224.3.72.0":
                        readTypeEnum = ReadTypeEnum.KWH1;
                        break;
                    case "13.26.0.1.1.1.12.0.0.0.0.2.0.0.224.3.72.0":
                        readTypeEnum = ReadTypeEnum.KVH2;
                        break;
                    case "13.26.0.1.1.1.12.0.0.0.0.1.0.0.224.3.73.0":
                        readTypeEnum = ReadTypeEnum.KVH1;
                        break;
                    case "13.26.0.1.1.1.12.0.0.0.0.2.0.0.224.3.73.0":
                        readTypeEnum = ReadTypeEnum.KVH2;
                        break;
                    case "13.8.0.6.1.1.8.0.0.0.0.1.0.0.224.3.38.0":
                        readTypeEnum = ReadTypeEnum.MDI1;
                        break;
                    case "13.8.0.6.1.1.8.0.0.0.0.2.0.0.224.3.38.0":
                        readTypeEnum = ReadTypeEnum.MDI2;
                        break;
                    default:
                        readTypeEnum = ReadTypeEnum.NONE;
                        break;
                }
                return readTypeEnum;
            }
        }
    }
