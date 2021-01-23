    var dictionary = doc.Descendants("RowDetails")
        .ToDictionary(
            x => x.Attribute("RowName").Value,
            x => x.Descendants("ColumnDetails")
                .Select(y => y.Attribute("ColumnName").Value)
                .PadIfFewerThan(3)
                .ToList()
            );
