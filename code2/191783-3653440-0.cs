    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    public class SongGroup
    {
        public SongGroup()
        {
            this.Songs = new List<Song>();
        }
    
        [XmlArrayItem("g", typeof(Song))]
        public List<Song> Songs { get; set; }
    }
    
    public class Song 
    { 
        public Song()
        {
        }
    
        [XmlElement("a")] 
        public string Artist { get; set; }
    
        [XmlElement("s")]
        public string SongTitle { get; set; }
    } 
    
    internal class Test
    {
        private static void Main()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SongGroup));
    
            SongGroup group = new SongGroup();
            group.Songs.Add(new Song() { Artist = "A1", SongTitle = "S1" });
            group.Songs.Add(new Song() { Artist = "A2", SongTitle = "S2" });
    
            using (Stream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, group);
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
