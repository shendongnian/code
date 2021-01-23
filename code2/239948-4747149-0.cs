    var header = columns[i].Name;
    if (header.StartsWith("F")) {
        int colIndex;
        if (Int32.TryParse(header.Substring(1), out colIndex))
        {
            if (colIndex == i)
                // auto assigned
        }
    }
