    // returns List<string>
    var columns = Enumerable.Range(0, reader.FieldCount)
                            .Select(reader.GetName)
                            .ToList();
    // columns joined on ", "
    var header = string.Join(", ", columns);
