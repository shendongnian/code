    using System.Xml.Serialization;
    using System.IO;
    .......
    StreamReader streamer = new StreamReader("yourgroup.xml");
    XmlSerializer serializer = new XmlSerializer(typeof(group));
    group x = (group)serializer.Deserialize(streamer);
    streamer.Close();
