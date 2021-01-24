    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Net;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string URL = @"http://musicbrainz.org/ws/2/release-group/?query=artist:%22coldplay%22%20AND%20primarytype:%22single%22";
            static void Main(string[] args)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.UserAgent = "Hello World Super Script";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                XDocument doc = XDocument.Load(response.GetResponseStream());
                XNamespace ns = doc.Root.GetDefaultNamespace();
                List<Group> groups = doc.Descendants(ns + "release-group").Select(x => new Group()
                {
                    title = (string)x.Element(ns + "title"),
                    name = (string)x.Descendants(ns + "name").FirstOrDefault(),
                    releaseTitles = x.Element(ns + "release-list").Descendants(ns + "title").Select(y => (string)y).ToArray()
                }).ToList();
            }
        }
        public class Group
        {
            public string title { get; set; }
            public string name { get; set; }
            public string[] releaseTitles { get; set; }
        }
    }
