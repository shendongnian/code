    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                Pulse pulse = new Pulse();
                XElement xPulse = new XElement("PULSE", new object[] {
                    new XAttribute("version",pulse.version),
                    new XElement("TIME_STAMP", new object[] {
                        new XAttribute("value", pulse.time.ToString()),
                        new XAttribute("timezone", pulse.timezone)
                    }),
                    new XElement("CARD", new object[] {
                        new XAttribute("type", pulse.cardType),
                        new XAttribute("version", pulse.version)
                    }),
                    new XElement("INFORMATION", new object[] {
                        new XElement("GENERAL", new object[] {
                            new XAttribute("key", pulse.key),
                            new XAttribute("value", pulse.keyValue)
                        })
                    }),
                    pulse.data.Select(x => new XElement("DATA_PACKET", new object [] {
                        new XAttribute("time_offset", x.time.ToString()),
                        x.data.Select(y => new XElement("Data", new object[] {new XAttribute("key", y.Key), new XAttribute("value", y.Value)}))
                    }))
                });
            }
        }
        public class Pulse
        {
            public DateTime time { get; set; }
            public string timezone { get; set; }
            public string cardType { get; set; }
            public string version { get; set; }
            public string key { get; set; }
            public string keyValue { get; set; }
            public List<Data> data { get;set;}
        }
        public class Data
        {
            public DateTime time { get; set; }
            public List<KeyValuePair<int, int>> data { get; set; }
        }
    }
