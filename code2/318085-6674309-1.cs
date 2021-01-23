    static void Main(string[] args)
        {
            var doc = XDocument.Load("test.xml");
            var result = from p in doc.Descendants("Form").Descendants("Field")
                         select new { ID = p.Element("id").Value, VALUE = p.Element("value").Value };
            foreach (var x in result)
                Console.WriteLine(x);
            var gr = from p in result
                     group p by p.VALUE into g
                     select new { Language=g.Key , Count=g.Count() };
            foreach (var x in gr)
                Console.WriteLine(string.Format("Language:{0} Count:{1}" , x.Language , x.Count));
            Console.Read();
        }
