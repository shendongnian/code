    int indexOfMax =
        data.Select((d, i) => new { Data = d, Index = i }) // associate an index with each item
            .Where(item => item.Data.tvd <= maxValue) // filter values greater than maxValue
            .Aggregate( // Compute the max
                new { MaxValue = double.MinValue, Index = -1 },
                (acc, item) => item.Data.tvd <= acc.MaxValue ? acc : new { MaxValue = item.Data.tvd, Index = item.Index },
                acc => acc.Index);
