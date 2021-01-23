        static void Main(string[] args)
        {
            XDocument loadedData = XDocument.Load("netten.xml");
            var data = from query in loadedData.Descendants("brand")
                       group query by new { A = query.Element("name"), B = query.Element("code"), C = query.Element("websiteurl"), D = query.Element("audiostreams") } into g
                       select new
                       {
                           Name = g.Key.A + "",
                           Code = g.Key.B + "",
                           Website = g.Key.C + "",
                           AudioStreams = g.Key.D.Elements("audiostream")
                                                    .Attributes("streamurl")
                                                    .Select(x => x.Value)
                                                    .ToArray()
                       };
            foreach (var x in data)
            {
                Console.WriteLine(x.Name);
                Console.WriteLine(x.Code);
                Console.WriteLine(x.Website);
                foreach (var url in x.AudioStreams)
                    Console.WriteLine(url);
            }
            Console.ReadKey();
        }
    }
