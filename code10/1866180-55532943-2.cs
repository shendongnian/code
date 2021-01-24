    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication107
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Vehicles vehicles = new Vehicles()
                {
                    vehicles = new List<Vehicle>() {
                        new Car() { make = "BMW"},
                        new Bike() { make = "Buffalo"},
                        new Truck() { make = "MAC"}
                    }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Vehicles));
                serializer.Serialize(writer, vehicles);
     
            }
        }
        public class Vehicles
        {
            [XmlElement("Vehicle")]
            public List<Vehicle> vehicles { get; set; }
        }
        [XmlInclude(typeof(Car))]
        [XmlInclude(typeof(Bike))]
        [XmlInclude(typeof(Truck))]
        public class Vehicle
        {
            public string make { get; set; }
        }
        public class Car : Vehicle
        {
        }
        public class Bike : Vehicle
        {
        }
        public class Truck : Vehicle
        {
        }
    }
