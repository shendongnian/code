    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using ProtoBuf;
    
    class Program
    {
        static void Main()
        {
            // load your data
            Model model;
            using(var file = File.OpenRead("my.xml"))
            {
                model = (Model)new XmlSerializer(typeof(Model)).Deserialize(file);
            }
            // write as protobuf-net
            using (var file = File.Create("my.bin"))
            {
                Serializer.Serialize(file, model);
            }
        }
    }
    
    [XmlRoot("XML"), ProtoContract]
    public class Model
    {
        [XmlElement("Group"), ProtoMember(1)]
        public List<Group> Groups { get; set; }
    
    }
    [ProtoContract]
    public class Group
    {
        [XmlAttribute("Name"), ProtoMember(1)]
        public string Name { get; set; }
    
        [XmlElement("PIN"), ProtoMember(2)]
        public List<Pin> Pins { get; set; }
    }
    [ProtoContract]
    public class Pin
    {
        [XmlAttribute("Name"), ProtoMember(1)]
        public string Name { get; set; }
    
        [XmlElement("PAIR"), ProtoMember(2)]
        public List<Pair> Pairs { get; set; }
    }
    [ProtoContract]
    public class Pair
    {
        [ProtoMember(1)]
        public int Voltage { get; set; }
        [ProtoMember(2)]
        public int Current { get; set; }
    }
