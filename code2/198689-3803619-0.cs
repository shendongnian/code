                var xd = XDocument.Parse(xml);
            if (xd != null)
            {
                var tests = xd.Descendants("Test");
                var microbiologyList = from test in tests
                             select new Microbiology
                             {
                                 Date = test.Element("Date").Value,
                                 ReadCode = test.Element("ReadCode").Value,
                                 Heading = test.Element("Rubric").Value
                             };
                var groupedResult = microbiologyList.OrderByDescending(y => y.Date).GroupBy(y => y.ReadCode);
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
                    Console.WriteLine(res.SubMicro.Count);
                }
            }
            Console.ReadLine();
        }
