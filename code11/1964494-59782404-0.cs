    KeyValues = item.Resources
        .Where(ConditionExpression)
        .GroupBy(g => new { g.ResourceId, g.Language }, 
             (x, y) => new { Max = y.OrderByDescending(o => o.Changed ?? o.Created).First() })
        .Select(s => new KeyValues
        {
            Language = s.Max.Language,
            KeyValue = s.Max.Value
        })
        .ToList();
