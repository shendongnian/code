    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    namespace EFToXml
    {
        public class MyEvent
        {
            public string Id { get; set; }
    
            public virtual List<MyDate> EventDates { get; set; }
        }
    
        public class MyDate
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                var myDate1 = new MyDate
                {
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays(1)
                };
                var eventDates = new List<MyDate> { myDate1 };
                var myEvent = new MyEvent
                {
                    Id = "1",
                    EventDates = eventDates
                };
    
                XmlSerializer serializer = new XmlSerializer(typeof(MyEvent));
                serializer.Serialize(File.Create(@"C:\Users\<UserName>\Source\Repos\myEvents.xml"), myEvent);
    
            }
        }
    }
