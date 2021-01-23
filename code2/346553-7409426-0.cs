    var noDuplicatesList = lines
        .GroupBy(l => l.PartNumber)
        .Select(group => group.First())
    foreach(var item in noDuplicatesList)
        Console.WriteLine("{0} {1} {2} {3}", 
            item.Name,
            item.PartDescription,
            item.PartNumber,
            item.Rotation
        );
