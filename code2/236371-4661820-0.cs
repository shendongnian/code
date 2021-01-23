    List<Person> people = new List<Person>(sourceData);
    XNamespace ns = @"http://schemas.openxmlformats.org/spreadsheetml/2006/main";
    Func<Person, XElement> nameColumn =
        (person) => new XElement(ns + "c", new XAttribute("r", "A1"),
                        new XElement(ns + "v", person.Name);
    Func<Person, XElement> ageColumn =
        (person) => new XElement(ns + "c", new XAttribute("r", "A2"),
                        new XElement(ns + "v", person.Age.ToString());
    var worksheet = new XDocument(
        new XElement(ns + "worksheet",
            new XElement(ns + "sheetData",
                people.Select((pp,rr) =>
                    new XElement(ns + "row",
                                 new XAttribute("r", (rr + 1).ToString()),
                                 nameColumn(pp),
                                 ageColumn(pp))
                ).ToArray()
            )
        )
    );
