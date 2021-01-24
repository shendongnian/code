    var final = table1.Where(i => i.Code == InputCode)
        .SelectMany(item1 => object.Select(code => item1.List.LastOrDefault(i => i.Code == code))
        .Where(item2 => item2 != null)
        .Select(item2 => new tempData
        {
            Code = item2.Code,
            Description = item2.Description,
        })
        .ToList();
