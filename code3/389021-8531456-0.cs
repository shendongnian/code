    XDocument xmlDoc = XDocument.Load("c:\\test.xml");
    var q = from c in xmlDoc.Descendants("User")
            select new
            {
                FirstName = (string)c.Attribute("FirstName"),
                LastName = (string)c.Attribute("LastName"),
                Age = (string)c.Attribute("age")
            };
    foreach (var user in q)
    {
        // This just shows how to access the properties.
        // You can do whatever else you want with them at this point
        Console.WriteLine(user.FirstName);
        Console.WriteLine(user.LastName);
        Console.WriteLine(user.Age);
    }
