    var dictionary = doc.Descendants("RowDetails")
        .ToDictionary(
            x => x.Attribute("RowName").Value,
            x => x.Descendants("ColumnDetails")
                .Select(y => y.Attribute("ColumnName").Value)
                .PadIfFewerThan(3)
            );
    foreach (var entry in dictionary)
        Console.WriteLine(@"""{0}""    {{""{1}""}}",
            entry.Key,
            string.Join(@""",""", entry.Value)
            );
