    string[] dataSplit = data.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
    var rows = from a in dataSplit
        let splitValues = a.Split(",")
        select new {
            Name    = splitValues[0],
            ID      = splitValues[1],
            Val     = splitValues[2],
            Time    = splitValues[3],
            Date    = splitValues[4]
        };
