    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    namespace XmlDemo
    {
    public class CharacterAttributes
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var characters = new List<CharacterAttributes>
                                 {
                                     new CharacterAttributes
                                         {
                                             Name = "Throgdor the Destroyer",
                                             Strength = 5,
                                             Dexterity = 10
                                         }, 
                                    new CharacterAttributes
                                        {
                                              Name = "Captain Awesome",
                                              Strength = 100,
                                              Dexterity = 9
                                        }
                                 };
            SerializeToXML(characters);
            var charactersReloaded = DeserializeFromXML(@"C:\temp\characters.xml");
        }
        static public void SerializeToXML(List<CharacterAttributes> characters)
        {
            var serializer = new XmlSerializer(typeof(List<CharacterAttributes>));
            var textWriter = new StreamWriter(@"C:\temp\characters.xml");
            using (textWriter)
            {
                serializer.Serialize(textWriter, characters);
                textWriter.Close();                
            } 
        }
        public static List<CharacterAttributes> DeserializeFromXML(string path)
        {
            var serializer = new XmlSerializer(typeof(List<CharacterAttributes>));
            var textReader = new StreamReader(path);
            var deserializedCharacters = new List<CharacterAttributes>();
            using (textReader)
            {
                deserializedCharacters = serializer.Deserialize(textReader) as List<CharacterAttributes>;    
            }
            return deserializedCharacters;
        }
    }
    }
