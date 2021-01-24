    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Telegram telegram = new Telegram();
                string type1 = "<Telegram xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchemainstance\" xmlns:p=\"LancePlatform\">" +
                                    "<Response>" +
                                    //The Rest of the XML Tree
                                    "</Response>" +
                                "</Telegram>";
                string type2 = "<Telegram xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchemainstance\" xmlns:p=\"LancePlatform\">" +
                                    "<Notification>" +
                                    //The Rest of the XML Tree
                                    "</Notification>" +
                                "</Telegram>";
                Telegram t1 = telegram.ProcessResponse(type1);
                object[] p1 = Telegram.Properties(t1);
                Telegram t2 = telegram.ProcessResponse(type2);
                object[] p2 = Telegram.Properties(t2);
            }
        }
           public class Telegram
        {
            public Response Response { get; set; }
            public Notification Notification { get; set; }
            public static object[] Properties(Telegram t)
            {
                PropertyInfo[] properties = typeof(Telegram).GetProperties();
                return properties.Select(x => x.GetValue(t,null)).Where(x => x != null).ToArray();
            }
            public Telegram ProcessResponse(string response)
            {
                Telegram telegram = new Telegram();
                using (TextReader reader = new StringReader(response))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Telegram));
                    try
                    {
                        // Do I have to check here if the Deserializion was valid, 
                        // and if not try the next Response Type
                        telegram = (Telegram)serializer.Deserialize(reader);
                        Console.WriteLine(telegram.Response);
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                return telegram; 
            }
           
        }
        public class Response
        {
        }
        public class Notification
        {
        }
    }
