    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    public class FileSignature
    {
        public override string ToString()
        {
            return string.Format("Description: '{0}', Extensions: '{1}', Signature: '{2}'"
                , Description
                , string.Join("|", (Extensions ?? new string[0]))
                , Signature
                );
        }
        public string Signature { get; set; }
        [XmlIgnore]
        public string[] Extensions { get; set; }
        [XmlElement(ElementName="Extension")]
        [System.ComponentModel.EditorBrowsable(
            System.ComponentModel.EditorBrowsableState.Never)]
        public string ExtensionsSerialized
        {
            get
            {
                return Extensions == null
                    ? ""
                    : string.Join("|", Extensions);
            }
            set
            {
                System.Console.WriteLine("Value: {0}", value);
                Extensions = value.Split('|');
            }
        }
        public string Description { get; set; }
    }
    [XmlRoot("Files")]
    public class FileSignatureCollection
    {
        public FileSignatureCollection()
        {
            Items = new List<FileSignature>();
        }
        [XmlElement("File")]
        public List<FileSignature> Items { get; set; }
    }
    class Program
    {
        static void Main()
        {
            using(var xml = File.OpenRead("test.xml"))
            {
                var serializer = new XmlSerializer(typeof(FileSignatureCollection));
                var signatures = (FileSignatureCollection)serializer.Deserialize(xml);
                foreach(var sig in signatures.Items)
                {
                    System.Console.WriteLine(sig);
                }
            }
        }
    }
