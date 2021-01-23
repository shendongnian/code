        using System.Xml.Serialization;
        public class MySettings
        {
        public String Setting1 { get; set; }
        public int Setting2 { get; set; }
        public String ToXml()
        {
            string settingsXml;
            var xmlSerializer = new XmlSerializer(typeof(MySettings));
            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, this);
                stream.Position = 0;
                using(var reader = new StreamReader(stream))
                {
                    settingsXml = reader.ReadToEnd();
                }
            }
            return settingsXml;
        }
        public static MySettings FromXml(string xml)
        {
            MySettings settings = null;
            using(MemoryStream stream  = new MemoryStream(System.Text.Encoding.Default.GetBytes(xml)))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (MySettings));
                settings = (MySettings) xmlSerializer.Deserialize(stream);
            }
            return settings;
        }
    }
