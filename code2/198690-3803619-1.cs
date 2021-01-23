        static void Main(string[] args)
        {
            var xd = XDocument.Parse(xml);
            if (xd != null)
            {
                var tests = xd.Descendants("Test");
                var groupedResult = (from test in tests
                             select new Microbiology
                             {
                                 Date = test.Element("Date").Value,
                                 ReadCode = test.Element("ReadCode").Value,
                                 Heading = test.Element("Rubric").Value
                             }).
                             OrderByDescending(y => y.Date).
                             GroupBy(y => y.ReadCode);
                var result = from item in groupedResult
                             select new Microbiology
                             {
                                 ReadCode = item.First().ReadCode,
                                 Date = item.First().Date,
                                 Heading = item.First().Heading,
                                 SubMicro = item.Skip(1).ToList()
                             };
                foreach (var res in result)
                {
                    Console.WriteLine(res.Heading);
                    foreach(var item in res.SubMicro)
                    Console.WriteLine(item.ReadCode + " " + item.Date);
                }
            }
            Console.ReadLine();
        }
