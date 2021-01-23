    var newList = list.GroupBy(x => new { x.City, x.ID })
    .Select
    (
        x =>
        {
            var subList = x.OrderBy(y => y.Date).ToList();
            return subList.Select((y, idx) => new MyObject
            {
                ID = y.ID,
                City = y.City,
                Date = y.Date,
                Value = y.Value,
                DiffToPrev = (idx == 0) ? 0 : y.Value - subList.ElementAt(idx-1).Value 
            });
        }
    )
    .SelectMany(x => x)
    .ToList();
