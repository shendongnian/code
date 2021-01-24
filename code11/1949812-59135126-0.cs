    var event = (from item in xmlDoc.Descendants("Event")
                where item.Element("id").Value == id
                select new Event
                {
                    id = item.Element("id").Value,
                    title = item.Element("title").Value,
                    Start = DateTime.Parse(item.Element("start").Value),
                    End = DateTime.Parse(item.Element("end").Value),
                    contacts = item.Element("contacts").Elements("contact").Select(c => new Contact
                    {
                        Id = c.Element("id").Value,
                        Name = c.Element("name").Value
                    }).ToList()
                }).FirstOrDefault();
