    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string URL = "https://samples.openweathermap.org/data/2.5/weather?q=London&mode=xml&appid=b6907d289e10d714a6e88b30761fae22";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(URL);
                XmlSerializer serializer = new XmlSerializer(typeof(Weather));
                Weather weather = (Weather)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("current")]
        public class Weather
        {
            public City city { get; set; }
            public Temperature temperature { get; set; }
            public Humidity humidity { get; set; }
            public Pressure pressure { get; set; }
            public Wind wind { get; set; }
        }
        public class City
        {
            [XmlAttribute()]
            public string name { get; set; }
            [XmlAttribute()]
            public string id { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
            public Sun sun { get; set; }
        }
        public class Sun
        {
            [XmlAttribute()]
            public DateTime rise { get; set; }
            [XmlAttribute()]
            public DateTime set { get; set; }        
        }
        public class Coord
        {
            [XmlAttribute()]
            public decimal lon { get; set; }
            [XmlAttribute()]
            public decimal lat { get; set; }
        }
        public class Temperature
        {
            [XmlAttribute()]
            public decimal value { get; set; }
            [XmlAttribute()]
            public decimal min { get; set; }
            [XmlAttribute()]
            public decimal max { get; set; }
        }
        public class Humidity
        {
            [XmlAttribute()]
            public decimal value { get; set; }
        }
        public class Pressure
        {
            [XmlAttribute()]
            public decimal value { get; set; }
        }
        public class Wind
        {
            public Speed speed { get; set; }
            public Direction direction { get; set; }
        }
        public class Speed
        {
            [XmlAttribute()]
            public decimal value { get; set; }
            [XmlAttribute()]
            public string name { get; set; }
        }
        public class Direction
        {
            [XmlAttribute()]
            public decimal value { get; set; }
            [XmlAttribute()]
            public string name { get; set; }
            [XmlAttribute()]
            public string code { get; set; }
        }
    }
