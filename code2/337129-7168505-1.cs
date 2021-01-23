    var problems = 
        from condition in xdoc.Descendants("Condition")
        select new {
            ObjectiveID = condition.Attribute("ObjectiveID").Value,
            Type = condition.Attribute("Type").Value,
            Ranges = Enumerable
                .Range(1, (int)condition.Attribute("CountRanges"))
                .Select(i => new {
                    Min = (int)condition.Attribute("Range" + i + "Min"),
                    Max = (int)condition.Attribute("Range" + i + "Max"),
                    Decimals = (int)condition.Attribute("Range" + i + "Decimals"),
                }).ToArray()
        };
