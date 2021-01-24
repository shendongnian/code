    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                 XmlReader reader = XmlReader.Create(INPUT_FILENAME);
                string xml = reader.ToString();
                XmlSerializer serializer = new XmlSerializer(typeof(DataRoot));
                DataRoot root = (DataRoot)serializer.Deserialize(reader);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME,settings);
                serializer.Serialize(writer, root);
            }
        }
        [XmlRoot(ElementName = "dataroot", Namespace = "")]
        public class DataRoot
        {
            [XmlElement(ElementName = "row", Namespace = "")]
            public List<DataModel> rows { get; set; }
        }
        [XmlRoot(ElementName = "row", Namespace = "")]
        public class DataModel
        {
            string Sifra { get; set; }
            public string Naziv { get; set; }
            public string JM { get; set; }
            public int Kolicina { get; set; }
            public float Cena_x0020_vp { get; set; }
            public float Cena_x0020_mp { get; set; }
            public float Cena_x0020_bod { get; set; }
            public string Slika { get; set; }
            public string Grupa { get; set; }
        }
    }
