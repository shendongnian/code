            var people = from p in xdoc.Root.Descendants("People")
                select new
                {
                    Name = p.Element("Person").Attribute("Name").Value,
                    Age = p.Element("Person").Attribute("Age").Value,
                    CauseOfAwesome = p.Element("Person").Attribute("CauseOfAwesome")
                };
            foreach (var n in people)
            {
                Console.WriteLine(n.Name);
                Console.WriteLine(n.Age);
                Console.WriteLine(n.CauseOfAwesome);
            }
