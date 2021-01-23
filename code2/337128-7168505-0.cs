    var problems = 
        from condition in xdoc.Descendants("Condition")
        select new {
            ObjectiveID = condition.Attribute("ObjectiveID").Value,
            Type = condition.Attribute("Type").Value,
            Ranges = Enumerable
                .Range(1, int.Parse(condition.Attribute("CountRanges").Value))
                .Select(i => new {
                    Min = int.Parse(condition.Attribute("Range" + i + "Min").Value),
                    Max = int.Parse(condition.Attribute("Range" + i + "Max").Value),
                    Decimals = int.Parse(condition.Attribute("Range" + i + "Decimals").Value),
                }).ToArray()
        };
