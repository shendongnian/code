    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication5
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                ObjMain objects = new ObjMain()
                {
                    ObjName = "Main",
                    objects = new List<ObjMain>() {
                        new objType1 { ObjName = "type 1" , X = 1.0F, Y = 2.0F, Height = 5F, Width = 10F},
                        new objType2 { ObjName = "type 2" , X = 1.5F, Y = 2.5F, Height = 5.5F, Width = 10.5F}
                    }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(ObjMain));
                serializer.Serialize(writer, objects);
            }
        }
        public class objType1 : ObjMain
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Height { get; set; }
            public float Width { get; set; }
        }
        public class objType2 : ObjMain
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Height { get; set; }
            public float Width { get; set; }
        }
        [XmlInclude(typeof(objType1))]
        [XmlInclude(typeof(objType2))]
        public class ObjMain
        {
            public string ObjName { get; set; }
            [XmlElement()]
            public List<ObjMain> objects { get; set; }
        }
    }
