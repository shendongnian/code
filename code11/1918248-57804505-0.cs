    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication128
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<root>" +
                       "<results>" +
                          "<result inum=\"802469000014312\">" +
                             "<field name=\"startedat\">2019-09-04T15:59:56.372</field>" +
                             "<field name=\"duration\">8</field>" +
                             "<field name=\"otherparties\">1043 (DEMO BLA BLA), 0519331839</field>" +
                             "<field name=\"switchcallid\">00001000081567605580</field>" +
                             "<field name=\"udfs\"></field>" +
                          "</result>" +
                          "<result inum=\"802469000014313\">" +
                             "<field name=\"startedat\">2019-09-04T16:00:31.414</field>" +
                             "<field name=\"duration\">6</field>" +
                             "<field name=\"otherparties\">1043 (DEMO BLA BLA), 0519331839</field>" +
                             "<field name=\"switchcallid\">00001000091567605608</field>" +
                             "<field name=\"udfs\"></field>" +
                          "</result>" +
                       "</results>" +
                    "</root>";
                StringReader sReader = new StringReader(xml);
                XmlReader xReader = XmlReader.Create(sReader);
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                Root root = (Root)serializer.Deserialize(xReader);
            }
        }
        [XmlRoot("root")]
        public class Root
        {
            [XmlArray("results")]
            [XmlArrayItem("result")]
            public WFOQueryDTO_Out[] WFOQueryDTO_Out { get; set; } 
        }
        public class WFOQueryDTO_Out
        {
            private DateTime startedat { get; set; }
            private int duration { get; set; }
            private string otherparties { get; set; }
            private string switchcallid { get; set; }
            private string udfs { get; set; }
            [XmlElement("field")]
            public Field[] field
            {
                get { return new Field[1]; }
                set
                {
                    foreach(Field _field in value)
                    {
                        switch (_field.name)
                        {
                            case "startedat":
                                startedat = DateTime.Parse(_field.value);
                                break;
                            case "duration":
                                duration = int.Parse(_field.value);
                                break;
                            case "otherparties" :
                                otherparties = _field.value;
                                break;
                            case "switchcallid" :
                                switchcallid = _field.value;
                                break;
                            case " udfs" :
                                udfs = _field.value;
                                break;
                        }
                    }
                }
            }
        }
        public class Field
        {
           
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlText]
            public string value { get; set; }
        }
    }
