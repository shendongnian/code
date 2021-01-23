    XDocument doc = ...;
    var batchClasses = doc.Descendants("node02")
        .Select(n => new
        {
            BatchClassName = (string)n.Attribute("name") ?? "",
            CustomPropertyNames = n.Descendants("CustomProperty")
                .Select(cp => (string)cp.Attribute("Name") ?? "")
                .ToList(),
            // Here's an example to select "EMAIL" custom property names
            EmailPropertyNames = n.Descendants("CustomProperty")
                .Select(cp => (string)cp.Attribute("Name") ?? "") // select the names...
                .Where(s => s.StartsWith("EMAIL"))                // that start with "EMAIL"
                .ToList(),                
        });
